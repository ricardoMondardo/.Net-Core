using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Dtos.Commons;
using WebApi.Helpers.Pagging;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/resources/")]
    public class ProductController : ControllerBase
    {
        /*
         * Provide just what is necessary, no more, no less
         * Use a hanful of http status code
         * 
         * 200 -   Ok
         * 201 -   Created
         * 400 -   Bad Request (Show why is bad Request)
         * 404 -   Not Found
         * 401 -   Unauthorized
         * 403 -   Forbidden
         */

        private IProductService _productService;
        private readonly IUrlHelper _urlHelper;

        public ProductController(IProductService productService, IUrlHelper urlHelper)
        {
            _productService = productService;
            _urlHelper = urlHelper;
        }

        [HttpGet("products", Name = "products")]
        [ProducesResponseType(200, Type = typeof(PagedList<ProductDTO>))]
        public IActionResult Products(PagingParams pagingParams)
        {
            var model = _productService.GetAll(pagingParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new PagingDTO<ProductDTO>()
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model),
                Items = model.List.Select(m => ToConvertDTO(m)).ToList(),
            };
            return Ok(outputModel);
        }

        [HttpGet("product/{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)] 
        public IActionResult Product(int id)
        {

            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(ToConvertDTO(product));
        }

        [HttpGet("product/{id}/invoices")]
        [ProducesResponseType(200, Type = typeof(ProductInvoicesDTO))]
        [ProducesResponseType(404)]
        public IActionResult ProductInvoices(int id)
        {

            var product = _productService.GetInvoices(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new ProductInvoicesDTO()
            {
                ProductDetail = product.ProductDetail,
                ProductGrade = product.ProductGrade,
                ProdutItems = product.ProdutItens.Select( p => new ProductItemDTO()
                {
                    Description = p.Description
                }).ToList()
            });
        }

        [HttpPost("product")]
        [ProducesResponseType(201, Type = typeof(ProductDTO))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] ProductDTO obj)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = ToConvertObj(obj);
            _productService.Add(product);

            return CreatedAtAction(nameof(Product), new { id = product.Id }, ToConvertDTO(product)); 
        }

        [HttpPut("product")]
        [ProducesResponseType(200, Type =typeof(ProductDTO))]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] ProductDTO obj)
        {

            if(!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            return Ok(obj);
        }

        #region Paging region
        private List<LinkInfo> GetLinks(PagedList<Product> list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink("products", list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("products", list.PageNumber, list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("products", list.NextPageNumber, list.PageSize, "nextPage", "GET"));

            return links;
        }

        private LinkInfo CreateLink(
            string routeName, int pageNumber, int pageSize,
            string rel, string method)
        {
            return new LinkInfo
            {
                Href = _urlHelper.Link(routeName,
                            new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }
        #endregion

        private ProductDTO ToConvertDTO(Product obj)
        {
            return new ProductDTO()
            {
                Id = obj.Id,
                Description = obj.Description,
                Active = obj.Active
            };
        }

        private Product ToConvertObj(ProductDTO obj)
        {
            return new Product()
            {
                Description = obj.Description,
                Active = obj.Active
            };
        }

    }
}
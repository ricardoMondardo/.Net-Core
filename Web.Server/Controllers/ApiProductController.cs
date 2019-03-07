using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Core.Models.Product;
using Web.Server.Dtos;
using Web.Server.Dtos.Commons;
using Web.Server.Helpers.Pagging;
using Web.Server.Services;
using Microsoft.AspNetCore.Authorization;

namespace Web.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/resources/")]
    [Authorize]
    public class ApiProductController : _BasePaggingController<ProductDTO>
    {
        private IProductService _productService;

        public ApiProductController(IProductService productService, IUrlHelper urlHelper) : base(urlHelper)
        {
            _productService = productService;
        }

        #region Methods Get
        [HttpGet("products")]
        [ProducesResponseType(200, Type = typeof(PagedList<ProductDTO>))]
        public IActionResult ProductByQuery(string q, PagingParams pagingParams)
        {
            IQueryable<ProductDTO> arr = null;

            if (q == null)
            {
                arr = _productService
                    .GetAllQueryable()
                    .Select(x => ToConvertDTO(x));
            } else
            {
                arr = _productService
                    .GetAllQueryable(q)
                    .Select(x => ToConvertDTO(x));
            }

            return PaggingListResult(pagingParams, "products", arr);
        }

        [HttpGet("products/{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)] 
        public IActionResult Product(string id)
        {

            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(ToConvertDTO(product));
        }

        [HttpGet("products/{id}/invoices")]
        [ProducesResponseType(200, Type = typeof(ProductInvoicesDTO))]
        [ProducesResponseType(404)]
        public IActionResult ProductInvoices(string id)
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
        #endregion

        #region Methods Post/Put
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
        #endregion

        #region Convertions
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
        #endregion

    }
}
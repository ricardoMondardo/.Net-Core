using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
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
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public List<ProductDTO> Products()
        {
            return _productService.GetAll().Select( p => new ProductDTO() {
                Id = p.Id,
                Description = p.Description
            }).ToList();
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

            return Ok(new ProductDTO()
            {
                Id = product.Id,
                Description = product.Description
            });
        }

        [HttpGet("product/{id}/invoices")]  //Change to Async
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
        public IActionResult Post([FromBody] Product obj)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.Add(obj);

            return CreatedAtAction(nameof(Product), new { id = obj.Id }, new ProductDTO()
            {
                Id = obj.Id,
                Description = obj.Description
            }); 
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

    }
}
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.Add(product);

            return Ok( new { id = product.Id });
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {

            var result = _productService.Get(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
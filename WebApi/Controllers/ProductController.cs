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
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<ProductDTO> GetAll()
        {
            return _productService.GetAll().Select( p => new ProductDTO() {
                Id = p.Id,
                Description = p.Description
            }).ToList();
        }

        [HttpGet("{qt:int}")]
        public List<ProductDTO> GetLatest(int qt)
        {
            return _productService.GetAll().Select(p => new ProductDTO()
            {
                Id = p.Id,
                Description = p.Description
            }).ToList();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)] 
        public IActionResult Get(int id)
        {

            //var result = _productService.GetWithIncludes(id);
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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _productService.GetAsync(id);

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

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(ProductDetailDTO))]
        [ProducesResponseType(404)] // IActionResult, because can have multiple return
        public IActionResult GetInclude(int id)
        {

            var product = _productService.GetWithIncludes(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new ProductDetailDTO()
            {
                Id = product.Id,
                Description = product.Description,
                MadeFor = product.ProductDetail.MadeFor,
                Gride = product.ProductGrade.Description,
                ProdutItems = product.ProdutItens.Select( p => new ProductItemDTO()
                {
                    Description = p.Description
                }).ToList()
            });
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        public IActionResult Post([FromBody] Product obj)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.Add(obj);

            //Firs and second param => headers
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, new ProductDTO()
            {
                Id = obj.Id,
                Description = obj.Description
            }); 
        }

    }
}
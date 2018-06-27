using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        #region Async
        #region Change
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)] // IActionResult, because can have multiple return
        public async Task<IActionResult> GetAsync(int param)
        {
            var result = await _productService.GetAsync(param);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        #endregion
        #endregion

        #region Sync
        #region Return
        [HttpGet]
        public IEnumerable<string> Count()
        {
            return new string[]
            {
            $"Products: { _productService.Count()}"
            };
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{qt:int}")]
        public List<Product> GetLatest(int qt)
        {
            return _productService.GetAll();
        }

        [HttpGet]
        public List<Product> GetAllIsUseTrue()
        {
            return _productService.GetAllIsUseTrue();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)] // IActionResult, because can have multiple return
        public IActionResult Get(int id)
        {

            var result = _productService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult Post([FromBody] Product obj)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.Add(obj);

            //Firs and second param => headers
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj.Description ); 
        }
        #endregion
        #endregion



    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Dtos.Todo;
using Web.Api.Services.Interface;
using Web.Repository.Models;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/todo/")]
    public class TodoController : Controller
    {

        private ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("OK");
        }

        [HttpPost("add")]
        [ProducesResponseType(201, Type = typeof(TodoDto))]
        [ProducesResponseType(400)]
        public IActionResult Add([FromBody] TodoDto obj)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Todo todo = new Todo()
            {
                Text = obj.Text
            };

            _todoService.Add(todo);

            //return CreatedAtAction(nameof(todo), obj);
            return Ok();
        }

    }
}

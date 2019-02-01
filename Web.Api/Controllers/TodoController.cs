using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Api.Dtos.Todo;
using Web.Api.Helpers.Pagging;
using Web.Api.Services.Interface;
using Web.Repository.Models;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/resources/")]
    [Authorize]
    public class TodoController : BasePaggingController<TodoDto>
    {

        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService, IUrlHelper urlHelper) : base(urlHelper)
        {
            _todoService = todoService;
        }

        [HttpGet("todos", Name = "todos")]
        [ProducesResponseType(200, Type = typeof(PagedList<TodoDto>))]
        public IActionResult Todos(PagingParams pagingParams)
        {
            var arr = _todoService
                .GetAllQueryable()
                .Select(x => 
                    new TodoDto() {
                            Text = x.Text,
                            Active = x.Active,
                            UserId = x.UserId
                    });

            return PaggingListResult(pagingParams, "todos", arr);
        }

        [HttpGet("Todos/{id}")]
        public IActionResult Todo(string id)
        {
            var todo = _todoService.Get(id);

            if(todo == null)
            {
                return NotFound();
            }

            var todoDto = new TodoDto() { Text = todo.Text, Active = todo.Active };

            return Ok(todoDto);
        }

        [HttpPost("todo")]
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

            return CreatedAtAction(nameof(Todo), new { id = todo.Id }, obj);
        }

        [HttpDelete("todos/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(string id)
        {

            var todo = _todoService.Get(id);

            if(todo == null)
            {
                return NotFound();
            }

            _todoService.Remove(todo.Id);

            return Ok("All right!, Todo removed");
        }


    }
}

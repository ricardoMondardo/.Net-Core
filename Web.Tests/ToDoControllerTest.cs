using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using Web.Api.Controllers;
using Web.Api.Dtos.Commons;
using Web.Api.Dtos.Todo;
using Web.Api.Helpers.Pagging;
using Web.Api.Services;
using Web.Repository.Models;
using Xunit;

namespace Web.Tests
{
    public class ToDoControllerTest
    {
        private readonly TodoService _todoService;
        private readonly MoqUrlHelper _httpHelper;
        public ToDoControllerTest()
        {
            _todoService = new TodoService(new DataContext().UnitOfWork);
            _httpHelper = new MoqUrlHelper();
        }            

        [Fact]
        public void ShouldReturnPaggingTodo()
        {
            //Seed
            Seed();

            //Controller
            var todoController = new TodoController(_todoService, _httpHelper.UrlHelper);
            todoController.ControllerContext.HttpContext = new DefaultHttpContext();
            OkObjectResult result = todoController.Todos(new PagingParams()) as OkObjectResult;

            //Check
            Assert.IsType<PagingDTO<TodoDto>>(result.Value);
            PagingDTO<TodoDto> resultObj = result.Value as PagingDTO<TodoDto>;

            Assert.True(resultObj.Items.Count == 2);
        }

        private void Seed()
        {
            _todoService.Add(new Todo() { Text = "abc" });
            _todoService.Add(new Todo() { Text = "abcA" });
        }
    }
}

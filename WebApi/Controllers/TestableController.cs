using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Testable")]
    public class TestableController : Controller
    {
        private ITestableService _testableService;

        public TestableController(ITestableService testableService)
        {
            _testableService = testableService;
        }

        [HttpGet]
        public string Get()
        {
            return "Hi..." + _testableService.SayHi();
        }
    }
}
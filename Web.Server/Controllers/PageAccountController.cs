using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Services.Interface;
using Web.Server.ViewModel;

namespace Web.Server.Controllers
{
    [Route("account/")]
    public class PageAccountController : Controller
    {
        private readonly IUserService _userService;
        public PageAccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new UserViewModel()
            {
                ActiveCode = "",
                ComeFromActiveLink = false
            };

            return View("~/views/pageaccount/index.cshtml", model);
        }

        [HttpGet("active")]
        public IActionResult Active([FromQuery]string email, [FromQuery]string token)
        {
            var result = _userService.ActiveUser(email, token);
            var model = new UserViewModel() {
                Email = email,
                ActiveCode = result ? token : "",
                ComeFromActiveLink = true
            };

            return View("~/views/pageaccount/index.cshtml", model);
        }
    }
}
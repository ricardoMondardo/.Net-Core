using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Server.Controllers
{
    public class PageAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
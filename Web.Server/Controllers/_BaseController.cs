using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Helpers;

namespace Web.Server.Controllers
{
    public class _BaseController : ControllerBase
    {
        public ActionResult BadRequestCustom(string msg)
        {
            return BadRequest(new BadRequestModel()
            {
                Title = msg,
                Errors = new List<ErrorModel>() { }
            });
        }
    }
}
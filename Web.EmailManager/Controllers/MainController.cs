using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.EmailManager.Interfaces;
using Web.EmailManager.Models;

namespace Web.EmailManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        private IEmailService _emailService;

        public MainController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> SendEmail()
        {

            var msg = new EmailMessage()
            {
                ToAddresses = new List<EmailAddress>()
                {
                    new EmailAddress() { Name = "Ricardo", Address = "ricardo9300@gmail.com"}
                },
                FromAddresses = new List<EmailAddress>()
                {
                    new EmailAddress() { Name = "Ricardo", Address = "noreplay@ricardo.com"}
                },
                Subject = "Email Test - This should be a subject",
                Content = "Email Test - This should be a content"
            };

            try
            {
                _emailService.Send(msg);
            } catch (Exception ex)
            {
                return StatusCode(500, new responseDTO { msg = ex.Message });
            }            

            return Ok();
        }
    }
}

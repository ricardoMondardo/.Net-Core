using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.EmailSender.Models;
using Web.EmailSender.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Server.Controllers
{
    [Route("api/emailSender/")]
    [ApiController]
    public class ApiEmailSenderController : ControllerBase
    {

        private readonly IEmailService _emailService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiEmailSenderController(IEmailService emailService, IHttpClientFactory httpClientFactory)
        {
            _emailService = emailService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("sendEmailTest")]
        public ActionResult<IEnumerable<string>> SendEmail()
        {

            var msg = BuildMessageTest();

            try
            {
                _emailService.Send(msg);
            } catch (Exception ex)
            {
                return StatusCode(500, new responseDTO { msg = ex.Message });
            }            

            return Ok();
        }

        [HttpGet("sendEmailTestByRest")]
        public async Task<ActionResult> SendEmailByRest()
        {
            try
            {
                return Ok(await _emailService.SendByRest(BuildMessageTest()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new responseDTO { msg = ex.Message });
            }

        }

        private EmailMessage BuildMessageTest()
        {
            return new EmailMessage()
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
        }
    }
}

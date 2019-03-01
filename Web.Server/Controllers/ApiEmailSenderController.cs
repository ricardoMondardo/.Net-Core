﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.EmailSender.Models;
using Web.EmailSender.Interfaces;

namespace Web.Server.Controllers
{
    [Route("api/emailSender/")]
    [ApiController]
    public class ApiEmailSenderController : ControllerBase
    {

        private IEmailService _emailService;

        public ApiEmailSenderController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("sendEmailTest")]
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
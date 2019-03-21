using System;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Dtos.AuthData;
using Web.Server.Services.Interface;
using Web.Core.Models.User;
using Microsoft.AspNetCore.Http;
using Web.EmailSender.Interfaces;
using Web.EmailSender.Models;
using System.Collections.Generic;

namespace Web.Server.Controllers
{
    [Route("api/Auth/")]
    [ApiController]
    public class ApiAuthController : _BaseController
    {
        IAuthService _authService;
        IUserService _userService;
        IEmailService _emailService;
        public ApiAuthController(IAuthService authService, IUserService userService, IEmailService emailService)
        {
            this._authService = authService;
            this._userService = userService;
            this._emailService = emailService;
        }

        [HttpPost("login")]
        public ActionResult<AuthDataDto> Login([FromBody]LoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _userService.GetSingle(model.Email);

            if (user == null) return BadRequestCustom("Email or Password invalid");
            
            if (!_authService.VerifyPassword(model.Password, user.Password))
            {
                return Unauthorized(new { msg = "Email or Password invalid" });
            }

            return _authService.GetAuthData(user);
        }

        [HttpPost("loginWithActiveCode")]
        public ActionResult<AuthDataDto> LoginWithActiveCode([FromBody]LoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _userService.GetSingle(model.Email);

            if (user == null) return BadRequestCustom("Email not found, please sign in");

            if (user.ActiveCode != model.Password)
            {
                if (_userService.UpdateActiveCode(user.Email))
                {
                    //Log that
                };
                return Unauthorized(new { msg = "this link is no longer valid, try to send a link again" });
            }

            return _authService.GetAuthData(user);
        }

        [HttpPost("register")]
        public ActionResult<AuthDataDto> Register([FromBody]RegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            if (!_userService.IsEmailUniq(model.Email)) return BadRequestCustom("Email already exists");

            if (!_userService.IsUsernameUniq(model.Username)) return BadRequestCustom("User name already exists");

            var activeCode = Guid.NewGuid().ToString();

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = _authService.HashPassword(model.Password),
                Active = false,
                ActiveCode = activeCode
            };
            _userService.Add(user);
                        
            try
            {
                _emailService.SendByRest(BuildEmailMessage(model.Username, model.Email, activeCode, "N"));
            }
            catch (Exception ex)
            {
                //Log somewhere
            }

            return _authService.GetAuthData(user);
        }

        [HttpPost("sendlinkactive")]
        public ActionResult SendLinkActive([FromQuery] string email, [FromQuery] string forgot)
        {

            if (!_userService.UpdateActiveCode(email)) return NotFound();

            var user = _userService.GetSingle(email);

            if (user == null) return NotFound();

            try
            {
                _emailService.SendByRest(BuildEmailMessage(email, email, user.ActiveCode, forgot));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new responseDTO { msg = ex.Message });
            }

            return Ok(new
            {
                msg = string.Format("Email has sent to: {0}", email)
            });
        }

        private EmailMessage BuildEmailMessage(string name, string email, string activeCode, string isForgot)
        {
            var baseUrl = HttpContext.Request.Host;
            var link = string.Format("https://{0}/account/active?email={1}&token={2}&forgot={3}", 
                baseUrl, 
                email, 
                activeCode, 
                isForgot ?? "N" );

            return new EmailMessage()
            {
                ToAddresses = new List<EmailAddress>()
                {
                    new EmailAddress() { Name = name, Address = email }
                },
                Subject = "Welcome to rmondardo.com",
                Content = string.Format("Link to active: {0}", link)
            };
        }

    }
}
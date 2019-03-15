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
        public ActionResult<AuthDataDto> Post([FromBody]LoginDto model)
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

        [HttpPost("register")]
        public ActionResult<AuthDataDto> Post([FromBody]RegisterDto model)
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

            var userData = _authService.GetAuthData(user);
            var link = string.Format("https://rmondardo.com/account/active?email={0}&token={1}", model.Email, activeCode);

            var emailMsg = new EmailMessage()
            {
                ToAddresses = new List<EmailAddress>()
                {
                    new EmailAddress() { Name = model.Username, Address = model.Email }
                },
                Subject = "Welcome to rmondardo.com",
                Content = string.Format("Link to active: {0}", link)
            };

            try
            {
                _emailService.Send(emailMsg);
            }
            catch (Exception ex)
            {
                //Log somewhere
            }

            return userData;
        }

    }
}
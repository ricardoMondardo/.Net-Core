using System;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Dtos.AuthData;
using Web.Server.Services.Interface;
using Web.Core.Models.User;
using Microsoft.AspNetCore.Http;

namespace Web.Server.Controllers
{
    [Route("api/Auth/")]
    [ApiController]
    public class ApiAuthController : ControllerBase
    {
        IAuthService _authService;
        IUserService _userService;
        public ApiAuthController(IAuthService authService, IUserService userService)
        {
            this._authService = authService;
            this._userService = userService;
        }

        [HttpPost("login")]
        public ActionResult<AuthDataDto> Post([FromBody]LoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _userService.GetSingle(model.Email);

            if (user == null)
            {
                return BadRequest(new { msg = "no user with this email" });
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
            {
                return Unauthorized(new { password = "invalid password" });
            }

            return _authService.GetAuthData(user);
        }

        [HttpPost("register")]
        public ActionResult<AuthDataDto> Post([FromBody]RegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = _userService.IsEmailUniq(model.Email);
            if (!emailUniq) return BadRequest(new { msg = "email already exists" });
            var usernameUniq = _userService.IsUsernameUniq(model.Username);
            if (!usernameUniq) return BadRequest(new { msg = "user name already exists" });

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = _authService.HashPassword(model.Password)
            };
            _userService.Add(user);

            return _authService.GetAuthData(user);
        }

    }
}
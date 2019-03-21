using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Server.Dtos.User;
using Web.Server.Services.Interface;

namespace Web.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/user/")]
    [Authorize]
    public class ApiUserController : ControllerBase 
    {

        private IUserService _userService;

        public ApiUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserData")]
        public IActionResult Get()
        {
            var userID = _userService.GetContextUserId(HttpContext.User);
            var userModel = _userService.Get(userID);

            var userDto = new UserDto()
            {
                Id = userModel.Id,
                Name = userModel.UserName + "**",
                Email = userModel.Email,
                Active = userModel.Active
            };

            return Ok(userDto);
        }

        [HttpPost("updatepass")]
        public IActionResult UpdatePass([FromBody] UpdatePass model)
        {
            var userID = _userService.GetContextUserId(HttpContext.User);
            var user = _userService.Get(userID);

            if (!_userService.UpdatePassword(user.Email ,model.Pass)) return NotFound();

            var userDto = new UserDto()
            {
                Id = user.Id,
                Name = user.UserName + "**",
                Email = user.Email,
                Active = user.Active
            };

            return Ok(userDto);


        }
    }
}

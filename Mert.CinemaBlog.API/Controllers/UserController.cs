using Mert.CinemaBlog.API.Controllers.Base;
using Mert.CinemaBlog.Model.UserDtos;
using Mert.CinemaBlog.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mert.CinemaBlog.API.Controllers
{
    
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public LoginDto Login([FromBody] LoginInputDto loginInputDto)
        {
            UserManager userManager = new();
            Shared shared = new();
            UserDto userDto = userManager.LoginCheck(loginInputDto.Username, loginInputDto.Password);

            if (userDto != null)
            {
                return new LoginDto()
                {
                    Webtoken = shared.GenerateToken(userDto),
                };
            }

            return new LoginDto();
        }

        [HttpGet("GetNameSurname")]
        public string GetNameSurname()
        {
            Shared shared = new();
            string token = HttpContext.Request.Headers["Authorization"];

            return shared.GetNameSurname(token);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.Service;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticateController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            string token = _userService.Authenticate(user, password);

            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(token);
        }
    }
}

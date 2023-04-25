using Library.Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Service;
using WebParking.Service.Services;

namespace WebParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");
                var logUser = _accountService.Authenticate(user);
                return Ok(TokenService.GenerateSecurityToken(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (await _accountService.UserAlreadyExists(model))
                return BadRequest("User already exists, please try something else");

            _accountService.Register(model);
            return StatusCode(201);
        }
    }
}

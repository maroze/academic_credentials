using Library.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Data.Entities;
using WebParking.Service;
using WebParking.Service.Services;

namespace WebParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest("Invalid request data");

                var loguser= _accountService.Authenticate(user);

                if (loguser.Result != null)
                    return Ok(_tokenService.GenerateSecurityToken(user));
                else
                    return BadRequest("Wrong password or login");
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

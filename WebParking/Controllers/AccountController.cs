using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
 
    }
}

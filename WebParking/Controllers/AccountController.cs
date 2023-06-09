using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebParking.Data.Entities;
using WebParking.Service.Models;
using WebParking.Service.Services;
using WebParking.Service.Services.Implementations;
using WebParking.Services.EmailServices;
using WebParking.Common.ViewModels.Auth;
using AutoMapper;

namespace WebParking.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    [Authorize]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, ITokenService tokenService, IEmailSender emailSender, IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        /// <summary>
        /// Информация о пользователе 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<IActionResult> GetUserAsync([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                var loguser = await _accountService.GetUserById(id);

                if (loguser != null)
                {
                    return Ok(loguser);
                }

                else
                    return BadRequest("User doesn't exist");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        /// <summary>
        /// Информация о пользователе 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("users/profiles")]
        public async Task<IActionResult> ProfileUserAsync([FromForm] ProfileUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                if (await _accountService.UserAlreadyExists(model.Email))
                    return BadRequest("User already exists, please try something else");

                var loguser = await _accountService.ChangeProfile(model);

                if (loguser != null)
                {
                    return Ok(await _tokenService.GenerateSecurityTokenAsync(_mapper.Map<UserEntityModel>(loguser)));
                }

                else
                    return BadRequest("User doesn't exist");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Авторизация пользователя в аккаунте
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                var loguser = await _accountService.Authenticate(user);

                if (loguser != null)
                {
                    UserRoleViewModel model = new UserRoleViewModel() { Role = loguser.Role, Token = await _tokenService.GenerateSecurityTokenAsync(_mapper.Map<UserEntityModel>(loguser)) };

                    return Ok(model);
                }

                else
                    return BadRequest("Wrong password or login");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotAsync([FromBody] ForgotPasswordViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var u = await _accountService.ForgotPassword(user);
                if (u != null)
                {

                    var token = _tokenService.GenerateSecurityTokenAsync(_mapper.Map<UserEntityModel>(u));

                    var callback = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme);
                    var message = new Message(new string[] { user.Email }, "Reset password token", "Восстановление пароля для личного кабинета SKYPARKING\r\nВы запросили восстановление пароля.\r\nЧтобы задать новый пароль, перейдите по этой ссылке.\r\n" + callback);

                    _emailSender.SendEmail(message);
                    return Ok();
                }
                else
                    return BadRequest("User doesn't exist");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model">логин, пароль, повторить пароль</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {

            if (await _accountService.UserAlreadyExists(model.Email))
                return BadRequest("User already exists, please try something else");

            if (!ModelState.IsValid)
                return BadRequest("Invalid request data");


            await _accountService.Register(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Выход пользователя из аккаунта
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        [HttpHead("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        [HttpPatch]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel resetPassword)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var user = await _accountService.ResetPassword(resetPassword);
                if (user != null)
                {
                    return Ok();
                }
                else
                    return BadRequest("Password doesn't change");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel pass)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var user = await _accountService.ChangePassword(pass);
                if (user != null)
                {
                    return Ok();
                }
                else
                    return BadRequest("Password doesn't match");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteUser([FromBody] int Id)
        {
            var user = await _accountService.DeleteUser(Id);
            if (user == null)
                return BadRequest("Account doesn't delete");
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}


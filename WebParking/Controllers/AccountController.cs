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
            _mapper=mapper;
        }

        /// <summary>
        /// Информация о пользователе 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<IActionResult> GetUserAsync([FromBody] int id)
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
        /// Авторизация пользователя в аккаунте
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                var loguser = _accountService.Authenticate(user);

                if (loguser.Result != null)
                {
                    return Ok(_tokenService.GenerateSecurityToken(_mapper.Map<UserEntityModel>(user)));
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
        public IActionResult Forgot([FromBody] ForgotPasswordViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                if (_accountService.ForgotPassword(user).Result != null)
                {

                    var token = _tokenService.GenerateSecurityToken(_mapper.Map<UserEntityModel>(user));

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
            
            if (await _accountService.UserAlreadyExists(model))
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
        [Authorize]
        [HttpHead("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                var user = await _accountService.ResetPassword(resetPassword);
            if (user!=null )
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

    }
}


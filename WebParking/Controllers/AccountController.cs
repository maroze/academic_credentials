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
using System.Net.Http;
using Newtonsoft.Json;

namespace WebParking.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    [Authorize]
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
        [HttpGet()]
        public async Task<IActionResult> GetUserAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');
            //Decode from base64 string
            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            //convert json to key value pair
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            var loguser = await _accountService.GetUserByEmail(values["email"]);

            return Ok(loguser);
        }
       
        /// <summary>
        /// Информация о пользователе 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("profiles")]
        public async Task<IActionResult> ProfileUserAsync([FromForm] ProfileUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');

            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);


            var loguser = await _accountService.ChangeProfile(model, values["email"]);

            if (loguser == null)
                return BadRequest("Не удалось сохранить изменения");

            return Ok(await _tokenService.GenerateSecurityTokenAsync(_mapper.Map<UserEntityModel>(loguser)));
        }

        /// <summary>
        /// Авторизация пользователя в аккаунте
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var loguser = await _accountService.Authenticate(user);

            if (loguser == null)
                return BadRequest("Неправильный пароль или логин");

            UserRoleViewModel model = new UserRoleViewModel() { Role = loguser.Role, Token = await _tokenService.GenerateSecurityTokenAsync(_mapper.Map<UserEntityModel>(loguser)) };
            return Ok(model);
        }

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotAsync([FromBody] ForgotPasswordViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");
            
            var u = await _accountService.ForgotPassword(user);

            var token = await _tokenService.GenerateSecurityTokenAsync(_mapper.Map<UserEntityModel>(u));
            var callback = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email }, "Reset password token", "Восстановление пароля для личного кабинета SKYPARKING\r\nВы запросили восстановление пароля.\r\nЧтобы задать новый пароль, перейдите по этой ссылке.\r\n" + callback);

            _emailSender.SendEmail(message);
            return Ok();
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model">логин, пароль, повторить пароль</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            if (await _accountService.UserAlreadyExists(model.Email))
                return BadRequest("Пользователь с такой почтой уже существует");

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

        [HttpPatch("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] RequestResetPasswordViewModel pass)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");
            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');
            
            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            ResetPasswordViewModel model = new ResetPasswordViewModel() { Email = values["email"], NewPassword = pass.NewPassword, NewConfirmPassword = pass.NewConfirmPassword };

            var user = await _accountService.ResetPassword(model);

            if (user == null)
                return BadRequest("Неудалось изменить пароль");

            return Ok();
        }

        [HttpPatch("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] RequestChangePasswordViewModel pass)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');
            //Decode from base64 string
            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            //convert json to key value pair
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            ChangePasswordViewModel model = new ChangePasswordViewModel() { Email = values["email"], OldPassword = pass.OldPassword, NewPassword = pass.NewPassword, ConfirmPassword = pass.ConfirmPassword };
            var user = await _accountService.ChangePassword(model);

            if (user == null)
                return BadRequest("Неудалось изменить пароль");

            return Ok();
        }

        [HttpDelete("users")]
        public async Task<IActionResult> DeleteUser()
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');
            //Decode from base64 string
            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            //convert json to key value pair
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            var user = await _accountService.DeleteUser(values["email"]);

            if (user == null)
                return BadRequest("Не удалось удалить аккаунт");

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}


using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebParking.Common;
using WebParking.Common.ViewModels.Auth;
using WebParking.Data.Entities;

namespace WebParking.Service.Models
{
    public class UserModel
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Фото профиля
        /// </summary>
        public byte[]? Avatar { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        [Phone]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Номер автомобиля пользователя
        /// </summary>
        public string? PlateNumder { get; set; }
    }
}

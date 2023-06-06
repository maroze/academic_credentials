using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Entities
{
    [Table("Users")]
    public class UserEntityModel
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Email(логин) пользователя
        /// </summary>
        [Column("username")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Роль (Админ, Менеджер, Пользователь)
        /// </summary>
        public IdentityRole Role { get; set; }

        /// <summary>
        /// Фото пользователя
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
        /// Номер пользователя
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Номер машины
        /// </summary>
        public string? PlateNumder { get; set; }
        public List<UserLotEntityModel> UserLots { get; set; }
    }
}

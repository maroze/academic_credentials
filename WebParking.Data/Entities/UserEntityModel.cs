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
        //Id пользователя
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        //Email(логин) пользователя
        [Column("username")]
        public string Email { get; set; }

        //Пароль пользователя
        [Column("password")]
        public string Password { get; set; }

        //Роль (Админ, Менеджер, Пользователь)
        [Column("role")]
        public IdentityRole Role { get; set; }
    }
}

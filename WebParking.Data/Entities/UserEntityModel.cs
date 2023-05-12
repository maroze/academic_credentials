using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Entities
{
    public enum Role
    {
        Administrator,
        Manager,
        User
    }
    [Table("Users")]
    public class UserEntityModel
    {
        //Id пользователя
        [Key]
        public int UserId { get; set; }

        //Email(логин) пользователя
        public string Email { get; set; }

        //Пароль пользователя
        public string Password { get; set; }

        //Роль (Админ, Менеджер, Пользователь)
        public Role Role { get; set; }
    }
}

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
        [Key]
        //ID пользователя
        public int Id { get; set; }

        //Имя пользователя
        public string Name { get; set; }

        //Логин пользователя
        public string Email { get; set; }

        //Пароль пользователя
        public string Password { get; set; }
    }
}

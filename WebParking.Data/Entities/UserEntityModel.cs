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
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}

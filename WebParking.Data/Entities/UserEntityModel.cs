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
        public Guid Id { get; set; }
        public string Email { get; set; }
        public byte [] Password { get; set; }
        public byte[] PasswordKey { get; set; }
        public Role Role { get; set; }
    }
}

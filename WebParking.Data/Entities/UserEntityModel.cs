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
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

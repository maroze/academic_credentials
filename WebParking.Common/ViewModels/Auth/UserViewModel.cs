using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Auth
{
    public class UserViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}

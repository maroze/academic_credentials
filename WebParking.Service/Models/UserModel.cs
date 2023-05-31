using Microsoft.AspNet.Identity;
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
        public string Email { get; set; }
        public string Password { get; set; }
        public IdentityRole? Role { get; set; }
    }
}

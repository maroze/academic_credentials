using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Auth
{
    public class ProfileUserViewModel
    {
        public IFormFile? Avatar { get; set; }

        [EmailAddress]
        public string? Email { get; set;}

        public string? FirstName { get; set;}

        public string? LastName { get; set;}

        [Phone]
        public string? PhoneNumber { get; set;}

        public string? PlateNumder { get; set;}
    }
}

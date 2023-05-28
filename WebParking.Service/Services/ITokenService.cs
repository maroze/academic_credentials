using Library.Common.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Entities;
using WebParking.Service.Models;

namespace WebParking.Service.Services
{
    public interface ITokenService
    {

        public string GenerateSecurityToken(UserModel user);
    }
}

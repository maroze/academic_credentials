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
        /// <summary>
        /// Генерация токена 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GenerateSecurityTokenAsync(UserEntityModel user);
    }
}

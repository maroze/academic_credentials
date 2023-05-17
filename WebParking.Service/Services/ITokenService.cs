using Library.Common.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Entities;

namespace WebParking.Service.Services
{
    public interface ITokenService
    {

        public string GenerateSecurityToken(string email);
    }
}

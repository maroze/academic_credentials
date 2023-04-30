using Library.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Service
{
    public interface ITokenService
    {
        public string GenerateSecurityToken(LoginViewModel user);
    }
}

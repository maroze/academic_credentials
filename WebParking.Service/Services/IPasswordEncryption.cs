using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common
{
    public interface IPasswordEncryption
    {
        public string HashPassword(string password);
    }
}

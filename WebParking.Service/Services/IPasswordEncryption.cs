using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common
{
    public interface IPasswordEncryption
    {
        /// <summary>
        /// Шифрование пароля пользователя
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string password);
    }
}

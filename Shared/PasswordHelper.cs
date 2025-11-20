using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class PasswordHelper
    {
        public static (string hash, string salt) HashPassword(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password, 0, password.Length)));
            return (hash, salt);
        }
        public static bool VerifyPassword(string password, string hash, string salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            var computed = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computed == hash;
        }
    }
}

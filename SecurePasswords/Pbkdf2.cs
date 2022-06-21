using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class Pbkdf2
    {
        private static int iterations = 100000;

        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, iterations))
            {
                return rfc2898.GetBytes(32);
            }
        }
    }
}

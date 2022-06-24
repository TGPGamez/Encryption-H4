using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class Encryption
    {
        public byte[] HashPassword(byte[] toBeHashed, byte[] salt, int iterations, int bytesize = 32)
        {
            byte[] hashed = new byte[bytesize];

            using (Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, iterations))
            {
                hashed = rfc2898.GetBytes(bytesize);
            }
            return hashed;
        }
    }
}

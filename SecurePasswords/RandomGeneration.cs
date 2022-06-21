using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public static class RandomGeneration
    {
        public static string GenerateRandomString(int length)
        {
            return Convert.ToBase64String(GetRandomByteArray(length));
        }


        static byte[] GetRandomByteArray(int length)
        {
            byte[] data = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(data);
            }

            return data;
        }
    }
}

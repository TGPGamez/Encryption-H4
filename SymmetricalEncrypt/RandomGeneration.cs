using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricalEncrypt
{
    public static class RandomGeneration
    {

        public static byte[] GenerateRandomByteArray(int length)
        {
            return GetRandomByteArray(length);
        }


        /// <summary>
        /// Generate random byte array using RNGCryptoServiceProvider
        /// </summary>
        /// <param name="length">Length of array</param>
        /// <returns></returns>
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

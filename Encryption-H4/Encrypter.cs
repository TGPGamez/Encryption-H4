using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEncrypt
{
    public class Encrypter
    {
        /// <summary>
        /// Method to encrypt a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Encrypted message</returns>
        public static string Enctrypt(string message)
        {
            string output = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];
                c++;
                output += c;
            }

            return output;
        }

        /// <summary>
        /// Method to decrypt a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Decrypted message</returns>
        public static string Decrypt(string message)
        {
            string output = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];
                c--;
                output += c;
            }

            return output;
        }

    }
}

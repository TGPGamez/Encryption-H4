using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SymmetricalEncrypt
{
    public class AesEncryption
    {
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memory = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memory, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.FlushFinalBlock();

                    return memory.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memory = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memory, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptoStream.FlushFinalBlock();

                    return memory.ToArray();
                }
            }
        }
    }
}

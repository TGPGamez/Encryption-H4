using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SymmetricalEncrypt
{
    public class Encryption
    {
        public byte[] EncryptAes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                return Encrypt(aes, dataToEncrypt, key, iv);
            }
        }

        public byte[] EncryptDes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                return Encrypt(des, dataToEncrypt, key, iv);
            }
        }

        private byte[] Encrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            symmetricAlgorithm.Mode = CipherMode.CBC;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            symmetricAlgorithm.Key = key;
            symmetricAlgorithm.IV = iv;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);

                cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }


        public byte[] DecryptAes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                return Decrypt(aes, dataToEncrypt, key, iv);
            }
        }

        public byte[] DecryptDes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                return Decrypt(des, dataToEncrypt, key, iv);
            }
        }

        private byte[] Decrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            symmetricAlgorithm.Mode = CipherMode.CBC;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            symmetricAlgorithm.Key = key;
            symmetricAlgorithm.IV = iv;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);

                cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }
    }
}

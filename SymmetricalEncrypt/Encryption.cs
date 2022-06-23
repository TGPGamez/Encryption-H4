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
        private SymmetricAlgorithm symmetricAlgorithm;

        public Encryption()
        {

        }

        public bool IsEncryptionSet()
        {
            return symmetricAlgorithm != null;
        }

        public void SetSymmetricalAlgorithm(SymmetricAlgorithm symmetricAlgorithm)
        {
            this.symmetricAlgorithm = symmetricAlgorithm;
            this.symmetricAlgorithm.GenerateIV();
            this.symmetricAlgorithm.GenerateKey();
        }


        public byte[] Encrypt(byte[] dataToEncrypt)
        {
            this.symmetricAlgorithm.Mode = CipherMode.CBC;
            this.symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, this.symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }


        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            this.symmetricAlgorithm.Mode = CipherMode.CBC;
            this.symmetricAlgorithm.Padding = PaddingMode.PKCS7;
            
            MemoryStream memoryStream = new MemoryStream(dataToDecrypt);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, this.symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] plainText = new byte[dataToDecrypt.Length];
            cryptoStream.Read(plainText, 0, dataToDecrypt.Length);

            return plainText;
        }
    }
}

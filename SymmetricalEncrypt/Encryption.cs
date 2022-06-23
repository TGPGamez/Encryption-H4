using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SymmetricalEncrypt
{
    /// <summary>
    /// Class to Encryption
    /// 
    /// This class can encrupt, decrypt and change the symmetricAlgorithm
    /// </summary>
    public class Encryption
    {
        private SymmetricAlgorithm symmetricAlgorithm;

        public Encryption()
        {

        }

        /// <summary>
        /// Check if the algorithm is set
        /// </summary>
        /// <returns>if is set</returns>
        public bool IsEncryptionSet()
        {
            return symmetricAlgorithm != null;
        }

        /// <summary>
        /// Set the SymmetricalAlgorithm and generate new IV and Key
        /// </summary>
        /// <param name="symmetricAlgorithm"></param>
        public void SetSymmetricalAlgorithm(SymmetricAlgorithm symmetricAlgorithm)
        {
            this.symmetricAlgorithm = symmetricAlgorithm;
            this.symmetricAlgorithm.GenerateIV();
            this.symmetricAlgorithm.GenerateKey();
        }


        /// <summary>
        /// Encrypt some data
        /// </summary>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] dataToEncrypt)
        {
            //Set the CipherMode
            this.symmetricAlgorithm.Mode = CipherMode.CBC;
            //Set the PaddingMode
            this.symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, this.symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);


            cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }


        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            //Set the CipherMode
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

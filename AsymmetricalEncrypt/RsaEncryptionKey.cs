using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AsymmetricalEncrypt
{
    public class RsaEncryptionKey : RsaEncryption
    {

        private RSAParameters publicKey;
        private RSAParameters privateKey;

        public RsaEncryptionKey(int keySize = 2048) : base(keySize)
        {

        }


        public override void AssignNewKey()
        {
            rsa.PersistKeyInCsp = false;
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }

        public override byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plainData;

            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(privateKey);
            plainData = rsa.Decrypt(dataToDecrypt, true);

            return plainData;
        }

        public override byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherData;

            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(publicKey);
            cipherData = rsa.Encrypt(dataToEncrypt, true);

            return cipherData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AsymmetricalEncrypt
{
    public class RsaEncryptionContainer : RsaEncryption
    {
        string containerName;

        public RsaEncryptionContainer(string containerName, int keySize = 2048) : base(keySize)
        {
            this.containerName = containerName;
        }



        public override void AssignNewKey()
        {
            CspParameters cspParameters = new CspParameters(1);
            cspParameters.KeyContainerName = containerName;
            cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;

            //Program needs to be run as administrator
            rsa = new RSACryptoServiceProvider(keySize, cspParameters) { PersistKeyInCsp = true };
        }

        public override byte[] DecryptData(byte[] dataToDecrypt)
        {
            return rsa.Decrypt(dataToDecrypt, false);
        }

        public override byte[] EncryptData(byte[] dataToEncrypt)
        {
            return rsa.Encrypt(dataToEncrypt, false);
        }

        public void DeleteKeyInCsp()
        {
            rsa.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AsymmetricalEncrypt
{
    public abstract class RsaEncryption
    {
        protected RSACryptoServiceProvider rsa;
        protected int keySize;

        public RsaEncryption(int _keySize = 2048)
        {
            rsa = new RSACryptoServiceProvider(_keySize);
            keySize = _keySize;
        }

        public abstract void AssignNewKey();

        public abstract byte[] EncryptData(byte[] dataToEncrypt);

        public abstract byte[] DecryptData(byte[] dataToDecrypt);
    }
}

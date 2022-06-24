using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricalEncrypt
{
    public class RsaEncryptionXML : RsaEncryption
    {
        private string publicKeyPath;
        private string privateKeyPath;

        public RsaEncryptionXML(string publicKeyPath, string privateKeyPath, int keySize = 2048) : base(keySize)
        {
            this.publicKeyPath = publicKeyPath;
            this.privateKeyPath = privateKeyPath;
        }


        public override void AssignNewKey()
        {
            rsa.PersistKeyInCsp = false;

            DeleteKeyFile(publicKeyPath);
            DeleteKeyFile(privateKeyPath);

            CreateFolder(publicKeyPath);
            CreateFolder(privateKeyPath);

            File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
            File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
        }

        public override byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plainData;

            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(File.ReadAllText(privateKeyPath));
            plainData = rsa.Decrypt(dataToDecrypt, false);

            return plainData;
        }

        public override byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] encrypt;

            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(File.ReadAllText(publicKeyPath));
            encrypt = rsa.Encrypt(dataToEncrypt, false);

            return encrypt;
        }

        private void DeleteKeyFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private void CreateFolder(string path)
        {
            string folderPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}

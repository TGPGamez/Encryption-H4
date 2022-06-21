using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class User
    {
        private string username;

        public string Username
        {
            get { return username; }
            private set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        private bool isLocked;

        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

        private string hashAlgorithm;

        public string HashAlgorithm
        {
            get { return hashAlgorithm; }
            private set { hashAlgorithm = value; }
        }

        private byte[] salt;

        public byte[] Salt
        {
            get { return salt; }
            private set { salt = value; }
        }



        public User(string username, string password, string hashAlgorithm, byte[] salt)
        {
            this.username = username;
            this.password = password;
            this.isLocked = false;
            this.hashAlgorithm = hashAlgorithm;
            this.salt = salt;
        }
    }
}

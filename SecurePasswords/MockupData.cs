using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class MockupData
    {
        List<User> users;
        public void AddUser(User user)
        {
            this.users.Add(user);
        }

        public MockupData()
        {
            this.users = new List<User>();
            string password = "Test1234";
            User user = new User();
            user.Username = "Test";
            user.Status = UserStatus.Active;
            Encryption encryption = new Encryption();

            string salt = RandomGeneration.GenerateRandomString(32);
            byte[] hashedPassW = encryption.HashPassword(password.GetBytesUTF8(), salt.GetBytesUTF8(), 500);
            user.Password = hashedPassW.ToBase64();
            user.Salt = salt;

            this.users.Add(user);


        }

        public User? GetUserByUsername(string username)
        {
            User user = this.users.Find(x => x.Username == username);
            return user != null ? user : null;
        }

        public int AddLoginAttempt(User user)
        {
            user.LoginAttempts++;
            return user.LoginAttempts;
        }

        public void ChangeStatus(User user, UserStatus status)
        {
            user.Status = status;
        }

        public void ResetLogin(User user)
        {
            user.LoginAttempts = 0;
            user.Status = UserStatus.Active;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class LoginManager
    {
        const int ITERATION_COUNT = 500;
        MockupData mockupData;

        public LoginManager()
        {
            mockupData = new MockupData();
        }


        public SystemMessage AddUser(string username, string password)
        {

            if (mockupData.GetUserByUsername(username) != null)
                return new SystemMessage(false, "User already exists", TypeSystem.UsernameExists);

            User user = new User();
            user.Username = username;
            
            Encryption encryption = new Encryption();

            string salt = RandomGeneration.GenerateRandomString(32);
            byte[] hashedPassW = encryption.HashPassword(password.GetBytesUTF8(), salt.GetBytesUTF8(), ITERATION_COUNT);
            user.Password = hashedPassW.ToBase64();
            user.Salt = salt;

            mockupData.AddUser(user);
      
            return new SystemMessage(true, "Added user successfully");
        }


        public SystemMessage Login(string username, string password)
        {
            User user = mockupData.GetUserByUsername(username);
            if (user == null)
            {
                return new SystemMessage(false, "Couldn't find user", TypeSystem.IncorrectUsername);
            }
            else if (user.Status == UserStatus.Locked)
            {
                return new SystemMessage(false, "User is locked", TypeSystem.UserLocked);
            }
            
            Encryption encryption = new Encryption();

            byte[] hashedPassW = encryption.HashPassword(password.GetBytesUTF8(), user.Salt.GetBytesUTF8(), ITERATION_COUNT);
            string passw = hashedPassW.ToBase64();

            if (user.Password == passw)
            {
                mockupData.ResetLogin(user);
                return new SystemMessage(true, "Login successfull");
            }

            return new SystemMessage(false, "Login failed, incorrect password", TypeSystem.IncorrectPassword);
        }


        public SystemMessage AddLoginAttempt(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new SystemMessage(false, "Username is empty", TypeSystem.IncorrectUsername);
            }

            User user = mockupData.GetUserByUsername(username);

            if (user == null)
            {
                return new SystemMessage(false, "Couldn't find user with that username", TypeSystem.IncorrectUsername);
            }

            int loginAttempts = mockupData.AddLoginAttempt(user);

            if (loginAttempts >= 5)
            {
                mockupData.ChangeStatus(user, UserStatus.Locked);
                return new SystemMessage(false, "User is now locked", TypeSystem.UserLocked);
            }

            return new SystemMessage(true, "Added attempt");
        }
    }
}

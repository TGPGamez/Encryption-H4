using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int LoginAttempts { get; set; }
        public UserStatus Status { get; set; }


        public User()
        {
            Status = UserStatus.Active;
        }
    }

    public enum UserStatus
    {
        Active,
        Locked
    }
}

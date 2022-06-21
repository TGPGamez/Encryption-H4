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
        public List<User> GetUsers()
        {
            return this.users;
        }
        public void AddUser(User user)
        {
            this.users.Add(user);
        }

        public MockupData()
        {
            this.users = new List<User>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class SystemMessage
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public TypeSystem SystemType { get; set; }

        public SystemMessage(bool status, string message)
        {
            Message = message;
            Status = status;
        }

        public SystemMessage(bool status, string message, TypeSystem type) : this(status, message)
        {
            SystemType = type;
        }

        public SystemMessage()
        {

        }
    }

    public enum TypeSystem
    {
        UsedLocked,
        UsernameExists,
        IncorrectPassword,
        IncorrectUsername
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public static class Converter
    {
        public static byte[] GetBytesUTF8(this string convertText)
        {
            return Encoding.UTF8.GetBytes(convertText);
        }

        public static string ToBase64(this byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHashing
{
    public static class Converter
    {

        public static string ToHex(this byte[] byteArray)
        {
            return BitConverter.ToString(byteArray);
        }

        public static string ToBase64(this byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
    }
}

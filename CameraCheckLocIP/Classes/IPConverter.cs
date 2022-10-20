using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CameraCheckLocIP.Classes
{
    internal class IPConverter
    {
        public static long IPAddressToLong(IPAddress address)
        {
            var v1 = address.GetAddressBytes();
            var v2 = v1.Reverse();
            var v3 = v2.ToArray();
            var v4 = BitConverter.ToInt64(v3,0);
            return BitConverter.ToInt64(address.GetAddressBytes().Reverse().ToArray(), 0);
        }

        public static string LongToString(long ip)
        {
            return IPAddress.Parse(ip.ToString()).ToString();
        }
    }
}

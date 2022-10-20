using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CameraCheckLocIP.Classes
{
    internal class IPEnumeration
    {
        ///<summary>
        /// IEnumerable<IPAddress>
        /// еще один способ перебора адресов, еще не проверенный
        ///<summary>
        ///<param name="IPFrom"></param>
        ///<returns>List<IPAddress></returns>
        static List<IPAddress> GetIPList(IPAddress ipFrom, IPAddress ipTo)
        {
            List<IPAddress> ipList = new List<IPAddress>();
            string[] arrayFrom = ipFrom.ToString().Split(new char[] { '.' });
            string[] arrayTo = ipTo.ToString().Split(new char[] { '.' });

            long firstIP = (long)(Math.Pow(256, 3) * Convert.ToInt32(arrayFrom[0]) + Math.Pow(256, 2) * Convert.ToInt32(arrayFrom[1]) + Math.Pow(256, 1) * Convert.ToInt32(arrayFrom[2]) + Convert.ToInt32(arrayFrom[3]));
            long lastIP = (long)(Math.Pow(256, 3) * Convert.ToInt32(arrayTo[0]) + Math.Pow(256, 2) * Convert.ToInt32(arrayTo[1]) + Math.Pow(256, 1) * Convert.ToInt32(arrayTo[2]) + (Convert.ToInt32(arrayTo[3]) + 1));

            for (long i = firstIP; i < lastIP; i++)
                ipList.Add(IPAddress.Parse(string.Join(".", BitConverter.GetBytes(i).Take(4).Reverse())));
            return ipList;
        }

        ///<summary>
        /// IEnumerable<IPAddress>
        /// еще один способ перебора адресов, еще не проверенный
        ///<summary>
        ///<param name="IPFrom"></param>
        ///<returns></returns>
        static List<IPAddress> EnumerateIpRange(IPAddress IPFrom, IPAddress IPTo)
        {
            List<IPAddress> ipList = new List<IPAddress>();
            var buffer = IPFrom.GetAddressBytes();

            do
            {
                IPFrom = new IPAddress(buffer);
                ipList.Add(IPFrom);
                int i = buffer.Length - 1;
                while (i >= 0 && ++buffer[i] == 0) i--;//нужно для сбрасывания на нули заполненные октеты, типа buffer = { 128, 255, 255, 255 } => { 129, 0, 0, 0 }               
            } while (!IPFrom.Equals(IPTo));

            return ipList;
        }

        static List<IPAddress> GetIPListDNS()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            List<IPAddress> ipList = new List<IPAddress>();

            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)//для того что бы искались адреса только IPv4
                {
                    ipList.Add(ip);
                }
            }
            return ipList;
        }

        public static IEnumerable<string> GetIP4Addresses()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())
                .Where(IPA => IPA.AddressFamily == AddressFamily.InterNetwork)
                .Select(x => x.ToString());
        }

        public static IPAddress[] GetIP4Array()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())
                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork).ToArray();
        }
    }
}

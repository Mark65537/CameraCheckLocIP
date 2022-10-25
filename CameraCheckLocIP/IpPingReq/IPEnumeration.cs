using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CameraCheckLocIP.IpPingReq
{
    internal class IPEnumeration
    {
        ///<summary>
        /// способ перебора IP адресов, еще не проверенный
        ///</summary>
        ///<param name="IPFrom">IP адресс начала перебора</param>
        ///<param name="IPTo">IP адресс конца перебора</param>
        ///<returns>List<IPAddress></returns>
        public static List<IPAddress> GetIPList(IPAddress ipFrom, IPAddress ipTo)
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
        /// способ перебора IP адресов. Предпочтителен
        ///</summary>
        ///<param name="IPFrom">IP адресс начала перебора</param>
        ///<param name="IPTo">IP адресс конца перебора</param>
        ///<returns>IList<IPAddress></returns>
        public static List<IPAddress> EnumerateIPRange(IPAddress IPFrom, IPAddress IPTo)
        {
            List<IPAddress> IPList = new List<IPAddress>();
            var buffer = IPFrom.GetAddressBytes();

            do
            {
                IPFrom = new IPAddress(buffer);
                IPList.Add(IPFrom);
                int i = buffer.Length - 1;
                while (i >= 0 && ++buffer[i] == 0) i--;//нужно для сбрасывания на нули заполненные октеты, типа buffer = { 128, 255, 255, 255 } => { 129, 0, 0, 0 }               
            } while (!IPFrom.Equals(IPTo));

            return IPList;
        }

        ///<summary>
        /// перебирает все IPv4 адреса в локальной сети, без заданного диапазона
        ///</summary>
        ///<returns>List<IPAddress></returns>
        public static List<IPAddress> GetIPListDNS()
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

        ///<summary>
        /// перебирает все IPv4 адреса в локальной сети, используя LINQ. Нельзя задать диапазон
        ///</summary>
        ///<returns>IEnumerable<string></returns>
        public static IEnumerable<string> GetIP4Addresses()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())
                .Where(IPA => IPA.AddressFamily == AddressFamily.InterNetwork)
                .Select(x => x.ToString());
        }

        ///<summary>
        /// самая короткая функция перебора IPv4 адресов в локальной сети, используя LINQ. 
        /// Нельзя задать диапазон
        ///</summary>
        ///<returns>IPAddress[]</returns>
        public static IPAddress[] GetIP4Array()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())
                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork).ToArray();
        }

        ///<summary>
        /// перебирает все IP адреса из заданого диапазона
        ///</summary>
        ///<param name="firstIPAddress">IP адресс начала перебора</param>
        ///<param name="lastIPAddress">IP адресс конца перебора</param>
        ///<returns>List<IPAddress></returns>
        private static List<IPAddress> IPAddressesRange(IPAddress firstIPAddress, IPAddress lastIPAddress)
        {
            var firstIPAddressAsBytesArray = firstIPAddress.GetAddressBytes();

            var lastIPAddressAsBytesArray = lastIPAddress.GetAddressBytes();

            Array.Reverse(firstIPAddressAsBytesArray);

            Array.Reverse(lastIPAddressAsBytesArray);

            var firstIPAddressAsInt = BitConverter.ToInt32(firstIPAddressAsBytesArray, 0);

            var lastIPAddressAsInt = BitConverter.ToInt32(lastIPAddressAsBytesArray, 0);

            var ipAddressesInTheRange = new List<IPAddress>();

            for (var i = firstIPAddressAsInt; i <= lastIPAddressAsInt; i++)
            {
                var bytes = BitConverter.GetBytes(i);

                var newIp = new IPAddress(new[] { bytes[3], bytes[2], bytes[1], bytes[0] });

                ipAddressesInTheRange.Add(newIp);
            }

            return ipAddressesInTheRange;
        }

        ///<summary>
        /// перебирает все IP адреса из заданого диапазона
        /// что бы перевести int обратно в string нужно опять же сделать так:
        /// string address = new IPAddress(BitConverter.GetBytes(intAddress)).ToString();
        ///</summary>
        ///<param name="from">IP адресс начала перебора</param>
        ///<param name="to">IP адресс конца перебора</param>
        ///<returns>IEnumerable<int></returns>
        private static IEnumerable<int> IPAddressesRange(string from, string to)
        {
            //нужно хэндлить исключения так как пользователь может ввести чушь
            int ipFrom = BitConverter.ToInt32(IPAddress.Parse(from).GetAddressBytes(), 0);
            int ipTo = BitConverter.ToInt32(IPAddress.Parse(to).GetAddressBytes(), 0);

            return Enumerable.Range(ipFrom, ipTo);
        }
    }
}

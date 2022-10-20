using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP.Classes
{
    internal class Checker
    {
        internal static void StartChecking(string IPFrom, string IPTo, List<string> ports)
        {
            var busy = true;

            try
            {
                CheckIPRange(IPAddress.Parse(IPFrom), IPAddress.Parse(IPTo), ports);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                busy = false;
            }
        }

        private static void CheckIPRange(IPAddress IPFrom, IPAddress IPTo, List<string> ports)
        {
            EnumerateIpRange(IPFrom, IPTo);
            long start = IPConverter.IPAddressToLong(IPFrom);//переводим IP в long для удобного подсчета
            long end = IPConverter.IPAddressToLong(IPTo);

            if (start > end) 
                throw new InvalidOperationException("Start > End");

            //Fill(start, end);

            

            for (long i = start; i <= end; i++)
            {
                Ping ping = new Ping();

                string ip=IPConverter.LongToString(i);
                Task<PingReply> pStat = ping.SendPingAsync(ip);

                if (pStat.Result.Status == IPStatus.Success)
                {
                    
                }
            }


        }

        private static void Fill(long start, long end)
        {
            for (long i = start; i <= end; i++)
            {
                //Ip = IPConverter.LongToString(i);
            }
        }

       
    }
}

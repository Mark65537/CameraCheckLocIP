using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP.MyClasses
{
    internal class PingChecking
    {
        public static List<IPAddress> CheckPingParForEach(List<IPAddress> IPAddresses, int timeout = 100)
        {
            List<IPAddress> SuccessIPList = new List<IPAddress>();

            Parallel.ForEach(IPAddresses, ip =>
            {
                Ping ping = new Ping();
                var pStat = ping.Send(ip, timeout);
                //pStat.Wait();

                if (pStat != null)
                {
                    if (pStat.Status == IPStatus.Success)
                    {
                        lock (SuccessIPList)
                        {
                            SuccessIPList.Add(ip);
                        }
                    }
                }
            });
            return SuccessIPList;
        }

        public static bool CheckPing(IPAddress ip, int timeout = 100)
        {
            Ping ping = new Ping();
            var pStat = ping.Send(ip, timeout);
            //pStat.Wait();

            if (pStat != null)
            {
                if (pStat.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            return false;
        }


        ///<summary>
        /// в данный момент не используется так как выдает не все значения
        ///<summary>
        ///<param name="IPAddresses"></param>
        ///<returns>List<IPAddress></returns>
        private static List<IPAddress> CheckPingInvoke(List<IPAddress> IPAddresses)
        {
            List<IPAddress> SuccessIPList = new List<IPAddress>();

            Parallel.ForEach(IPAddresses, ip =>
            {
                Func<PingReply> pingDelegate = () => new Ping().Send(ip);

                IAsyncResult result = pingDelegate.BeginInvoke(r => pingDelegate.EndInvoke(r), null);

                //wait for thread to complete
                result.AsyncWaitHandle.WaitOne(100);

                if (result.IsCompleted)
                {
                    //Ping Succeeded do something
                    //PingReply reply = (PingReply)result;
                    lock (SuccessIPList)
                    {
                        SuccessIPList.Add(ip);
                    }
                }
            });

            MessageBox.Show("Invoke for");
            return SuccessIPList;
        }
    }
}

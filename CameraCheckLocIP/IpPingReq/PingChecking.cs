using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP.IpPingReq
{
    internal class PingChecking
    {
        ///<summary>
        /// метод для Пинга IP адресов из списка, использующий Parallel.ForEach для перебора
        ///</summary>
        ///<param name="IPAddresses">список IP адресов которые нужно Пинговать</param>
        ///<param name="timeout">Время задержки для Ping</param>
        ///<returns>List<IPAddress></returns>
        public static List<IPAddress> CheckPingParForEach(List<IPAddress> IPAddresses, int timeout = 100)
        {
            List<IPAddress> SuccessIPList = new List<IPAddress>();

            Parallel.ForEach(IPAddresses, ip =>
            {
                Ping ping = new Ping();
                var pStat = ping.Send(ip, timeout);

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

        ///<summary>
        /// метод для Пинга IP адреса. Предпочтителен
        ///</summary>
        ///<param name="ip">IP адрес который нужно Пинговать</param>
        ///<param name="timeout">Время задержки для Ping</param>
        ///<returns>bool</returns>
        public static bool CheckPing(IPAddress ip, int timeout = 100)
        {
            Ping ping = new Ping();
            var pStat = ping.Send(ip, timeout);

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
        /// Не используется так как выдает не все значения
        ///</summary>
        ///<param name="IPAddresses">список IP адресов которые нужно Пинговать</param>
        ///<returns>List<IPAddress></returns>
        public static List<IPAddress> CheckPingInvoke(List<IPAddress> IPAddresses)
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

            return SuccessIPList;
        }
    }
}

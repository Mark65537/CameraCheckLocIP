using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP.Classes
{
    internal class Checker
    {
        #region мои переменные
         private static string _httprequest="http://{0}:{1}/cgi-bin/admin/privacy.cgi";
        #endregion
        internal static void StartChecking(string IPFrom, string IPTo, List<string> ports)
        {
            var busy = true;

            try
            {
                IPAddress IPAFrom = IPAddress.Parse(IPFrom);
                IPAddress IPATo = IPAddress.Parse(IPTo);

                CheckIPRange(IPAFrom, IPATo, ports);
                var v=CheckPingParForEach(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));
                CheckHTTP(v, ports);
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

        private static void CheckHTTP(List<IPAddress> SuccessIPList, List<string> ports)
        {
            string address;
            Parallel.ForEach(SuccessIPList, (ip, port) =>
            {
                if (ports.Count > 0)
                {
                    var adresswithport = string.Format("{0}:{1}", ip, ports[0]);
                    address = string.Format(_httprequest, adresswithport);
                }
                else
                {
                    address = string.Format(_httprequest, ip);
                }

                using (var client = new HttpClient())
                {
                    try
                    {
                        var task = client.GetAsync(address);
                        task.Wait();
                        var HttpStatusCode = task.Result.StatusCode;
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, address);
                    }
                }
            });
        }

        private static void CheckIPRange(IPAddress IPFrom, IPAddress IPTo, List<string> ports)
        {

            //long start = BitConverter.ToInt32(IPFrom.GetAddressBytes(), 0);//переводим IP в long для удобного подсчета
            //long end = BitConverter.ToUInt32(IPTo.GetAddressBytes(), 0);

            if (IPFrom.Address > IPTo.Address)//делаем проверку что бы адрес начала поиска был меньше
                throw new InvalidOperationException("Start > End");

            //Task.Run(() =>
            //{
            

                //List<IPAddress> ipList = IPEnumeration.EnumerateIPRange(IPFrom, IPTo);//для проверки

                
        }

        private static List<IPAddress> CheckPingParForEach(List<IPAddress> IPAddresses)
        {
            List<IPAddress> SuccessIPList = new List<IPAddress>();

            Parallel.ForEach(IPAddresses, ip =>
            {
                Ping ping = new Ping();
                var pStat = ping.SendPingAsync(ip, 100);
                pStat.Wait();

                if (pStat != null)
                {
                    if (pStat.Result.Status == IPStatus.Success)
                    {
                        lock (SuccessIPList)
                        {
                            SuccessIPList.Add(ip);
                        }                        
                    }
                }
            });

            MessageBox.Show("Parallel for");
            return SuccessIPList;
        }
    }
}

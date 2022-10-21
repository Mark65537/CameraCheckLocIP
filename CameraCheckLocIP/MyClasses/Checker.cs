using CameraCheckLocIP.Model;
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
         private static string _httpRequest="http://{0}/cgi-bin/admin/privacy.cgi";
        #endregion
        internal static async void StartChecking(string IPFrom, string IPTo, List<string> ports)
        {

            try
            {
                IPAddress IPAFrom = IPAddress.Parse(IPFrom);
                IPAddress IPATo = IPAddress.Parse(IPTo);

                CheckIPRange(IPAFrom, IPATo);
                //var v1 = CheckPingInvoke(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));
                var v2 = CheckPingParForEach(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));
                CheckHTTP(v2, ports);
            }
            catch (Exception)
            {
                MessageBox.Show("Проверка не выполнена");
            }
        }

        public static IEnumerable<HttpStatusCode> CheckHTTP(List<IPAddress> SuccessIPList, List<string> ports)
        {
            string address;
            //var ip=SuccessIPList[0];
            //Parallel.ForEach(SuccessIPList, (ip) =>{
            foreach (var ip in SuccessIPList)
                if (ports.Count > 0)
                {
                    //Parallel.ForEach(ports, (port) =>  
                    foreach (var port in ports)
                    {
                        string adresswithport = string.Format("{0}:{1}", ip, port);
                        address = string.Format(_httpRequest, adresswithport);

                        using (var client = new HttpClient())
                        {
                            //try
                            //{
                            var task = client.GetAsync(address);
                            task.Wait();
                            yield return task.Result.StatusCode;
                            //var HttpStatusCode = task.Result.StatusCode;
                            //}
                            //catch (OperationCanceledException)
                            //{
                            //    throw;
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message, address);
                            //}
                        }
                    }
                    //);

                }
                else
                {
                    address = string.Format(_httpRequest, ip);

                    using (var client = new HttpClient())//повтор. упростить
                    {
                        //try
                        //{
                            var task = client.GetAsync(address);
                            task.Wait();
                            yield return task.Result.StatusCode;
                            //var HttpStatusCode = task.Result.StatusCode;
                        //}
                        //catch (OperationCanceledException)
                        //{
                        //    throw;
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message, address);
                        //}
                    }
                }
            //});
        }

        public static CheckingResult CheckHTTPforTask(IPAddress ip, List<string> ports)
        {
            string address;
            
            
                if (ports.Count > 0)
                {

                        string adresswithport = string.Format("{0}:{1}", ip, ports[0]);
                        address = string.Format(_httpRequest, adresswithport);

                        using (var client = new HttpClient())
                        {
                            var task = client.GetAsync(address);
                            task.Wait();
                            CheckingResult cr=new CheckingResult();
                            cr.Ip = ip.ToString();
                            cr.Port = ports[0];
                            cr.HttpStatusCode = task.Result.StatusCode;
                            return cr;

                        }
                }
                else
                {
                    address = string.Format(_httpRequest, ip);

                    using (var client = new HttpClient())//повтор. упростить
                    {
                        
                        var task = client.GetAsync(address);
                        task.Wait();
                        CheckingResult cr = new CheckingResult();
                        cr.Ip = ip.ToString();
                        cr.Port = ports[0];
                        cr.HttpStatusCode = task.Result.StatusCode;
                        return cr;
                }
                }
            return null;
        }

        public static void CheckIPRange(IPAddress IPFrom, IPAddress IPTo)
        {

            //long start = BitConverter.ToInt32(IPFrom.GetAddressBytes(), 0);//переводим IP в long для удобного подсчета
            //long end = BitConverter.ToUInt32(IPTo.GetAddressBytes(), 0);

            if (IPFrom.Address > IPTo.Address)//делаем проверку что бы адрес начала поиска был меньше
                throw new InvalidOperationException("Start > End");

            //Task.Run(() =>
            //{
            

                //List<IPAddress> ipList = IPEnumeration.EnumerateIPRange(IPFrom, IPTo);//для проверки

                
        }

        public static List<IPAddress> CheckPingParForEach(List<IPAddress> IPAddresses)
        {
            List<IPAddress> SuccessIPList = new List<IPAddress>();

            Parallel.ForEach(IPAddresses, ip =>
            {
                Ping ping = new Ping();
                var pStat = ping.Send(ip, 100);
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

            //MessageBox.Show("Parallel for");
            return SuccessIPList;
        }


        ///<summary>
        /// выдает не все значения
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

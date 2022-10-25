using CameraCheckLocIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CameraCheckLocIP.IpPingReq
{
    internal class HTTPChecking
    {
        #region мои переменные
         public string httpRequest = "http://{0}/cgi-bin/admin/privacy.cgi";
        #endregion

        ///<summary>
        /// отправка HTTP-запроса на определенные IP адресса
        ///</summary>
        ///<param name="IPList">список IP адрессов</param>
        ///<param name="ports">список портов</param>
        ///<param name="httpRequest">http-запрос</param>
        ///<returns>IEnumerable<HttpStatusCode></returns>
        public static IEnumerable<HttpStatusCode> CheckHTTP(List<IPAddress> IPList, List<string> ports, string httpRequest)
        {
            string address;
            foreach (var ip in IPList)
                if (ports.Count > 0)
                {
                    foreach (var port in ports)
                    {
                        string adresswithport = string.Format("{0}:{1}", ip, port);
                        address = string.Format(httpRequest, adresswithport);

                        using (var client = new HttpClient())
                        {
                            var task = client.GetAsync(address);
                            task.Wait();
                            yield return task.Result.StatusCode;
                        }
                    }
                }
                else
                {
                    address = string.Format(httpRequest, ip);

                    using (var client = new HttpClient())//повтор. упростить
                    {
                        var task = client.GetAsync(address);
                        task.Wait();
                        yield return task.Result.StatusCode;
                    }
                }
        }

        ///<summary>
        /// отправка HTTP-запроса на определенный IP адресс. предпочтительней
        ///</summary>
        ///<param name="ip">IP адресс</param>
        ///<param name="ports">список портов</param>
        ///<param name="httpRequest">http-запрос</param>
        ///<returns>List<CheckingResult></returns>
        public static List<CheckingResult> CheckHTTP(IPAddress ip, List<string> ports, string httpRequest)
        {
            string address;
            List<CheckingResult> crL = new List<CheckingResult>();

            if (ports.Count > 0)
            {
                foreach (var port in ports)
                {
                    string adresswithport = string.Format("{0}:{1}", ip, port);
                    address = string.Format(httpRequest, adresswithport);

                    using (var client = new HttpClient())
                    {
                        try
                        {
                            client.Timeout = TimeSpan.FromMilliseconds(1500);
                            var task = client.GetAsync(address);
                            task.Wait();
                            crL.Add(new CheckingResult(ip: ip,
                                                       port: port,
                                                       httpstatuscode: task.Result.StatusCode));
                        }

                        catch (AggregateException ex)
                        {
                            Console.WriteLine(ex.ToString());//вывод на консоль так как данная информация мне не нужна, но может понадобиться в будующем
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());//вывод на консоль так как данная информация мне не нужна, но может понадобиться в будующем                            
                        }
                    }
                }
                return crL;
            }
            else
            {
                address = string.Format(httpRequest, ip);

                using (var client = new HttpClient())//повтор. упростить
                {
                    var task = client.GetAsync(address);
                    task.Wait();
                    crL.Add(new CheckingResult(ip: ip,
                                               port: null,
                                               httpstatuscode: task.Result.StatusCode));
                    return crL;
                }
            }
        }

        ///<summary>
        /// отправка HTTP-запроса на определенный IP адресс
        ///</summary>
        ///<param name="ip">IP адресс</param>
        ///<param name="port">порт</param>
        ///<param name="httpRequest">http-запрос</param>
        ///<returns>CheckingResult</returns>
        public static CheckingResult CheckHTTP(IPAddress ip, string port, string httpRequest)
        {
            string address;
            CheckingResult cr;

            if (string.IsNullOrEmpty(port))
            {
                address = string.Format(httpRequest, ip);
            }
            else
            {
                string adresswithport = string.Format("{0}:{1}", ip, port);
                address = string.Format(httpRequest, adresswithport);
            }

            using (var client = new HttpClient())
            {
                var task = client.GetAsync(address);
                task.Wait();
                
                cr = new CheckingResult(ip: ip,
                                        port: port,
                                        httpstatuscode: task.Result.StatusCode);
                return cr;
            }
        }
    }
}

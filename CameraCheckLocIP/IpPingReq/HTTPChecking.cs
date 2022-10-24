using CameraCheckLocIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CameraCheckLocIP.MyClasses
{
    internal class HTTPChecking
    {
        #region мои переменные
         public string httpRequest = "http://{0}/cgi-bin/admin/privacy.cgi";
        #endregion
        public static IEnumerable<HttpStatusCode> CheckHTTP(List<IPAddress> SuccessIPList, List<string> ports, string httpRequest)
        {
            string address;
            foreach (var ip in SuccessIPList)
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

        public static List<CheckingResult> CheckHTTP(IPAddress ip, List<string> ports, string httpRequest)
        {
            string address;
            List<CheckingResult> Lcr = new List<CheckingResult>();
            var cts = new CancellationTokenSource();
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
                            Lcr.Add(new CheckingResult(ip: ip,
                                                       port: port,
                                                       httpstatuscode: task.Result.StatusCode));
                        }

                        catch (AggregateException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());                            
                        }
                    }
                }
                return Lcr;
            }
            else
            {
                address = string.Format(httpRequest, ip);

                using (var client = new HttpClient())//повтор. упростить
                {
                    var task = client.GetAsync(address);
                    task.Wait();
                    Lcr.Add(new CheckingResult(ip: ip,
                                               port: null,
                                               httpstatuscode: task.Result.StatusCode));
                    return Lcr;
                }
            }
        }

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

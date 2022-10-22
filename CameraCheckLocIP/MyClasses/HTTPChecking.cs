using CameraCheckLocIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CameraCheckLocIP.MyClasses
{
    internal class HTTPChecking
    {
        #region мои переменные
         private static string _httpRequest = "http://{0}/cgi-bin/admin/privacy.cgi";
        #endregion
        public static IEnumerable<HttpStatusCode> CheckHTTP(List<IPAddress> SuccessIPList, List<string> ports)
        {
            string address;
            foreach (var ip in SuccessIPList)
                if (ports.Count > 0)
                {
                    foreach (var port in ports)
                    {
                        string adresswithport = string.Format("{0}:{1}", ip, port);
                        address = string.Format(_httpRequest, adresswithport);

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
                    address = string.Format(_httpRequest, ip);

                    using (var client = new HttpClient())//повтор. упростить
                    {

                        var task = client.GetAsync(address);
                        task.Wait();
                        yield return task.Result.StatusCode;
                    }
                }
        }

        public static CheckingResult CheckHTTP(IPAddress ip, string port)
        {
            string address;

            if (string.IsNullOrEmpty(port))
            {
                address = string.Format(_httpRequest, ip);
            }
            else
            {
                string adresswithport = string.Format("{0}:{1}", ip, port);
                address = string.Format(_httpRequest, adresswithport);
            }

            using (var client = new HttpClient())
            {
                var task = client.GetAsync(address);
                task.Wait();
                CheckingResult cr = new CheckingResult();
                cr.IP = ip.ToString();
                cr.Port = port;
                cr.HttpStatusCode = task.Result.StatusCode;
                return cr;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CameraCheckLocIP.Model
{
    public class CheckingResult
    {
        public IPAddress IP { get; set; }

        public string Port { get; set; }

        public IPStatus? IPStatus { get; set; }

        public HttpStatusCode? HttpStatusCode { get; set; }

        public CheckingResult(IPAddress ip, string port, HttpStatusCode httpstatuscode)
        {
            IP = ip;
            Port = port;
            HttpStatusCode = httpstatuscode;
        }

        //public string Error { get; set; }//оставлен на запас
    }
}

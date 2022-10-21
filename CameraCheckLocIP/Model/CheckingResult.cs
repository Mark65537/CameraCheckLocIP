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
        public string Ip { get; set; }

        public string Port { get; set; }

        public IPStatus? IPStatus { get; set; }

        public HttpStatusCode? HttpStatusCode { get; set; }

        //public string Error { get; set; }//оставлен на запас
    }
}

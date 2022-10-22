using CameraCheckLocIP.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP.Classes
{
    internal class Checker : IDisposable
    {
        #region мои переменные
         private static string _httpRequest="http://{0}/cgi-bin/admin/privacy.cgi";
        #endregion
        public static async void test(MainForm form)
        {
            //var result = await Task.Run(() => { Thread.Sleep(5000); return DateTime.Now.ToShortDateString(); }); //имитация длительного процесса            
            //return result;
            //MainForm form = new MainForm();
            //form.lV_output.Items.Add("текст");
            Stopwatch stopwatch = new Stopwatch();//создаем объект для того что бы засеч время
            stopwatch.Start();//засекаем время начала операции
            for (int i = 0; i < 10; i++)
            {
                var v = await Task.Run(() => { Thread.Sleep(5000); return DateTime.Now.ToString(); });
                form.lV_output.Items.Add(v.ToString());
                //return 
                //yield return ;
            }
            //return null;
        }
        internal static async void StartChecking(MainForm form, string IPFrom, string IPTo, List<string> ports)
        {
            Stopwatch stopwatch = new Stopwatch();//создаем объект для того что бы засеч время
            try
            {                
                stopwatch.Start();//засекаем время начала операции

                IPAddress IPAFrom = IPAddress.Parse(IPFrom);
                IPAddress IPATo = IPAddress.Parse(IPTo);
                List<IPAddress> SuccessIPList = new List<IPAddress>();

                CheckIPRange(IPAFrom, IPATo);
                
                var IPList=IPEnumeration.EnumerateIPRange(IPAFrom, IPATo);

                foreach (var ip in IPList)
                {
                    var canPing = await Task.Run(() => { return CheckPing(ip, (int)form.nUD_timeout.Value); });
                    if (canPing)
                    {
                        SuccessIPList.Add(ip);
                    }
                    else
                    {
                        form.tB_output.Text += $"IP адрес {ip} не доступен\r\n";
                    }                    
                }
                //SuccessIPList = CheckPingParForEach(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));

                for (int i = 0; i < SuccessIPList.Count; i++)//нельзя использовать foreach так как нужен итератор
                {
                    var v = await Task.Run(() => { return CheckHTTPforTask(SuccessIPList[i],ports); });
                    form.lV_output.Items.Add(v.IP);
                    form.lV_output.Items[i].SubItems.Add(v.Port);
                    form.lV_output.Items[i].SubItems.Add(v.HttpStatusCode.ToString());                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверка не выполнена: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stopwatch.Stop();//останавливаем счётчик            
                TimeSpan ts = stopwatch.Elapsed;

                form.l_totalTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", // Создаем строку, содержащую время выполнения операции.
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10);

                form.b_startScan.Enabled = true;
                MessageBox.Show("Проверка выполнена успешна", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        internal static async void StartChecking(string IPFrom, string IPTo, List<string> ports)
        {
            Stopwatch stopwatch = new Stopwatch();//создаем объект для того что бы засеч время
            
            try
            {
                stopwatch.Start();//засекаем время начала операции

                IPAddress IPAFrom = IPAddress.Parse(IPFrom);
                IPAddress IPATo = IPAddress.Parse(IPTo);

                CheckIPRange(IPAFrom, IPATo);
                //var v1 = CheckPingInvoke(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));
                var v2 = CheckPingParForEach(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));
                CheckHTTP(v2, ports);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверка не выполнена: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stopwatch.Stop();//останавливаем счётчик            
                TimeSpan ts = stopwatch.Elapsed;

                //form.l_totalTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", // Создаем строку, содержащую время выполнения операции.
                //                    ts.Hours, ts.Minutes, ts.Seconds,
                //                    ts.Milliseconds / 10);
                MessageBox.Show("Проверка выполнена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

        public static bool CheckPing(IPAddress ip, int timeout=100)
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

        public void Dispose()
        {
            
        }
    }
}

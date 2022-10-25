using CameraCheckLocIP.IpPingReq;
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
         private string _httpRequest="http://{0}/cgi-bin/admin/privacy.cgi";//находиться здесь что бы было проще найти в коде
         private CancellationTokenSource _cancTokSource = new CancellationTokenSource();
        #endregion

        ///<summary>
        /// асинхронный метод для начала проверки
        ///<summary>
        ///<param name="form">ссылка на форму</param>
        ///<param name="IPFrom">IP адресс начала перебора</param>
        ///<param name="IPTo">IP адресс конца перебора</param>
        ///<param name="ports">ссылка с портами по которым будет проходить проверка</param>
        ///<param name="pingTimeout">значение задержки для ping</param>
        ///<returns></returns>
        public async void StartCheckingAsync(MainForm form, string IPFrom, string IPTo, List<string> ports, int pingTimeout=100)
        {
            _cancTokSource.Token.ThrowIfCancellationRequested();

            Stopwatch stopwatch = new Stopwatch();//создаем объект для того что бы засеч время
            TimeSpan ts;

            try
            {                
                stopwatch.Start();//засекаем время начала операции

                IPAddress IPAFrom = IPAddress.Parse(IPFrom);
                IPAddress IPATo = IPAddress.Parse(IPTo);
                List<IPAddress> SuccessIPList = new List<IPAddress>();

                if (IPAFrom.Address > IPATo.Address)//делаем проверку что бы адрес начала поиска был меньше
                    throw new InvalidOperationException("Не верный порядок IP");
                
                var IPList=IPEnumeration.EnumerateIPRange(IPAFrom, IPATo);

                //проверка Ping
                foreach (var ip in IPList)
                {
                    var canPing = await Task.Run(() => { return PingChecking.CheckPing(ip, pingTimeout); }, _cancTokSource.Token);
                    if (canPing)
                    {
                        SuccessIPList.Add(ip);
                    }
                    else
                    {
                        form.tB_output.Text += $"IP адрес {ip} не доступен\r\n";
                    }                    
                }

                //Проверка запросом
                for (int i = 0; i < SuccessIPList.Count; i++)//нельзя использовать foreach так как нужен итератор
                {
                    var Res = await Task.Run(() => { return HTTPChecking.CheckHTTP(SuccessIPList[i],ports, _httpRequest); }, _cancTokSource.Token);
                    if (Res != null)
                    {
                        for (int k = 0; k < Res.Count; k++)//нельзя использовать foreach так как нужен итератор
                        {
                            //TODO: сюда можно вставить условия для того что бы отображались только IP камер. Например: if(Res[k].HttpStatusCode.ToString().equals("OK"))
                            form.lV_output.Items.Add(Res[k].IP.ToString());
                            int li= form.lV_output.Items.Count - 1;
                            form.lV_output.Items[li].EnsureVisible();
                            form.lV_output.Items[li].SubItems.Add(Res[k].Port);
                            form.lV_output.Items[li].SubItems.Add(Res[k].HttpStatusCode.ToString());                            
                        }                        
                    }                    
                }

            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException || ex is ObjectDisposedException)
                {
                    throw;
                }

                MessageBox.Show($"Проверка не выполнена: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stopwatch.Stop();//останавливаем счётчик            
                ts = stopwatch.Elapsed;

                form.l_totalTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", 
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10);// Создаем строку, для удобного отображения времени.

                form.b_startScan.Enabled = true;
                return;
            }

            stopwatch.Stop();//останавливаем счётчик            
            ts = stopwatch.Elapsed;

            form.l_totalTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", // Создаем строку, содержащую время выполнения операции.
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);

            form.b_startScan.Enabled = true;
            MessageBox.Show("Проверка выполнена успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        ///<summary>
        /// метод для начала проверки
        ///<summary>
        ///<param name="IPFrom">начальное значение IP</param>
        ///<param name="IPTo">последнее значение IP</param>
        ///<param name="ports">ссылка с портами по которым будет проходить проверка</param>      
        ///<returns>string</returns>
        public string StartChecking(string IPFrom, string IPTo, List<string> ports)
        {
            Stopwatch stopwatch = new Stopwatch();//создаем объект для того что бы засеч время
            TimeSpan ts;
            string totalTime;

            try
            {
                stopwatch.Start();//засекаем время начала операции

                IPAddress IPAFrom = IPAddress.Parse(IPFrom);
                IPAddress IPATo = IPAddress.Parse(IPTo);

                if (IPAFrom.Address > IPATo.Address)//делаем проверку что бы адрес начала поиска был меньше
                    throw new InvalidOperationException("Не верный порядок IP");

                var v2 = PingChecking.CheckPingParForEach(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));
                HTTPChecking.CheckHTTP(v2, ports, _httpRequest);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверка не выполнена: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stopwatch.Stop();//останавливаем счётчик            
                ts = stopwatch.Elapsed;

                totalTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10);// Создаем строку, для удобного отображения времени.
                return totalTime;
            }

            stopwatch.Stop();//останавливаем счётчик            
            ts = stopwatch.Elapsed;

            totalTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", // Создаем строку, содержащую время выполнения операции.
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
            
            MessageBox.Show("Проверка выполнена успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return totalTime;
        }                     

        public void Dispose()
        {
            _cancTokSource.Cancel();
            _cancTokSource.Dispose();//рекомендуется использовать для очистки памяти
        }
    }
}

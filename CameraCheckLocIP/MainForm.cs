using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraCheckLocIP.Classes;

namespace CameraCheckLocIP
{
    public partial class MainForm : Form
    {
        #region мои переменные
         private TimeSpan _sequentalTime;
        #endregion
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{

            //    //lV_output.Items[1].Text = i.ToString();
            //    lV_output.Items.Add(await Task.Run(() => { Thread.Sleep(3000); return DateTime.Now.ToLongTimeString(); }));

            //    lV_output.Items[i].SubItems.Add(i.ToString());
            //    lV_output.Items[i].SubItems.Add("port");
            //}
            Text += Assembly.GetExecutingAssembly().GetName().Version;
            MinimumSize = Size;
        }

        private void b_plus_Click(object sender, EventArgs e)
        {
            AddPortForm aPF = new AddPortForm();
            
            //Создаем анонимный метод - обработчик события FormClosing дочерней формы (возникающего перед закрытием)
            //Подписаться на событие необходимо до открытия дочерней формы
            //Использовать событие FormClosed не стоит, так как оно возникает уже после закрытия формы, когда все переменные формы уже уничтожены
            aPF.FormClosing += (sender1, e1) =>
            {
                if (!aPF.addPortNum.Equals(string.Empty))
                {
                    lB_port.Items.Add(aPF.addPortNum);
                }
            };

            aPF.ShowDialog();
        }

        private void b_minus_Click(object sender, EventArgs e)
        {
            if (lB_port.SelectedIndex > -1)
            {
                lB_port.Items.RemoveAt(lB_port.SelectedIndex);
            }
        }

        private void tB_IPFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 46) // цифры, клавиша BackSpace и точка
            {
                e.Handled = true;
            }
        }

        private void tB_IPTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 46) // цифры, клавиша BackSpace и точка
            {
                e.Handled = true;
            }
        }

        private  void b_startScan_Click(object sender, EventArgs e)
        {
            b_startScan.Enabled = false;

            lV_output.Items.Clear();
            //Stopwatch stopwatch = new Stopwatch();//создаем объект для того что бы засеч время
            //stopwatch.Start();//засекаем время начала операции

            List<string> PortList = lB_port.Items.Cast<string>()
                                         .Select(item => item.ToString())
                                         .ToList();//исправить, возможно можно сократить

            Checker.StartChecking(this, tB_IPFrom.Text, tB_IPTo.Text, PortList);

            //try
            //{
            //    //Task.Run(() =>{
                

            //    Checker.CheckIPRange(IPAFrom, IPATo);
            //    var SuccessIPList = Checker.CheckPingParForEach(IPEnumeration.EnumerateIPRange(IPAFrom, IPATo));

            //    for (int i = 0; i < SuccessIPList.Count; i++)
            //    {
            //        //var v = await Task.Run(() => { return Checker.CheckHTTPforTask(SuccessIPList[i], PortList); });
            //        //lV_output.Items.Add(v.Ip);
            //        //lV_output.Items[i].SubItems.Add(v.Port);
            //        //lV_output.Items[i].SubItems.Add(v.HttpStatusCode.ToString());
            //        //lV_output.Items[i].SubItems.Add();
            //    }


            //    //lV_output.Items.SubItems.Add(i.ToString());
            //    //lV_output.Items.SubItems.Add("port");
            //    //foreach (var HTTPStat in Checker.CheckHTTP(SuccessIPList, PortList))
            //    //    {
            //    //        lV_output.Text = HTTPStat.ToString();
            //    //    }
            //    //});
            //    //Checker.StartChecking(tB_IPFrom.Text, tB_IPTo.Text, PortList);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка");
            //}
            //finally
            //{
            //    stopwatch.Stop();//останавливаем счётчик            
            //    TimeSpan ts = stopwatch.Elapsed;

            //    l_totalTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", // Создаем строку, содержащую время выполнения операции.
            //                        ts.Hours, ts.Minutes, ts.Seconds,
            //                        ts.Milliseconds / 10);

            //    b_startScan.Enabled = true;
            //}
        }
    }
}

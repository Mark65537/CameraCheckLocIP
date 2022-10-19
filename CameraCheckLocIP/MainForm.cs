using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP
{
    public partial class MainForm : Form
    {
        //мои переменные

        //мои переменные конец
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
    }
}

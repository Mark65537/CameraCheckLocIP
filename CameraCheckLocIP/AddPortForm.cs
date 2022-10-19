using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCheckLocIP
{
    public partial class AddPortForm : Form
    {
        //мои переменные
         public string addPortNum = string.Empty;
        //мои переменные конец
        public AddPortForm()
        {
            InitializeComponent();
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            int portNum = int.Parse(tB_port.Text);

            if (portNum > -1 && portNum < 65536)
            {
                addPortNum = tB_port.Text;//подумать здесь над оптиметизацией
                Close();
            }
            else
            {
                MessageBox.Show("Введите число от 0 до 65535","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                        
        }

        //для того что бы можно было вводить только цыфры
        private void tB_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && num != 8)
            {
                e.Handled = true;
            }
        }
    }
}

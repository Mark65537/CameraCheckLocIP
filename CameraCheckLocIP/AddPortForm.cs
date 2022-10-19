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
            MainForm mainForm = new MainForm();
            //mainForm.lB_port;
        }
    }
}

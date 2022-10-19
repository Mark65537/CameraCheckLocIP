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
            new AddPortForm().Show();            
        }

        private void b_minus_Click(object sender, EventArgs e)
        {
            if (lB_port.SelectedIndex > -1)
            {
                lB_port.Items.RemoveAt(lB_port.SelectedIndex);
            }
        }
    }
}

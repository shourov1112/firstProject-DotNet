using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        
        private void Start_Load(object sender, EventArgs e)
        {
            this.progressBar1.Width = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Visible = true;
            this.progressBar1.Value = this.progressBar1.Value + 4;
            if (this.progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                Login lo = new Login();
                lo.ShowDialog();
                
            }
        }
    }
}

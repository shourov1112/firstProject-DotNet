using StockManagementSystem.DLL;
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
    public partial class UserInformation : Form
    {
        public UserInformation()
        {
            InitializeComponent();
            ShowAllData();
        }
        UserStatusManage userStatusManage = new UserStatusManage();
        private void ShowAllData()
        {
            DataTable dt=userStatusManage.ShowAllData();
            if (dt.Rows.Count > 0)
            {
                userInformationGridView.DataSource = dt;
            }
            
        }

        private void userInformationGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.userInformationGridView.Rows[e.RowIndex].Cells["Sno"].Value = (e.RowIndex + 1).ToString();
        }
    }
}

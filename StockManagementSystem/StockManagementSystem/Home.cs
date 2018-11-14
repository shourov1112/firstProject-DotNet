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
    public partial class Home : Form
    {
        int userIdd = 0;
        public Home(int userId)
        {
            InitializeComponent();
            this.userIdd = userId;
        }

        private void companyMenuItem_Click(object sender, EventArgs e)
        {
            CompanySetup companySetup = new CompanySetup(userIdd);
            companySetup.ShowDialog();
        }

        private void categoryMenuItem_Click(object sender, EventArgs e)
        {
            CategorySetup categorySetup = new CategorySetup(userIdd);
            categorySetup.ShowDialog();
        }

        private void itemSetupMenuItem_Click(object sender, EventArgs e)
        {
            ItemSetup itemSetup = new ItemSetup(userIdd);
            itemSetup.ShowDialog();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockIn stockIn = new StockIn(userIdd);
            stockIn.ShowDialog();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOut stockOut = new StockOut();
            stockOut.ShowDialog();
        }

        private void searchItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchItem searchItem = new SearchItem();
            searchItem.ShowDialog();
        }

        private void searchByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchByDate search = new SearchByDate();
            search.ShowDialog();
        }

        private void userModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation user = new UserInformation();
            user.ShowDialog();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

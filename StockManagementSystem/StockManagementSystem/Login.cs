using StockManagementSystem.DLL;
using StockManagementSystem.Model;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string userName = String.Empty;
        string password = String.Empty;
        LoginManage loginManage = new LoginManage();
        private void SubmitButton_Click(object sender, EventArgs e)
        {
             userName= userNameTextBox.Text;
             password = passwordTextBox.Text;
             bool check = CheckTextBoxNull();
             if (check)
             {
                 Submit();
             }
             else
             {
                 MessageBox.Show("TextBox Must be filled");
             }
        }

        private void Submit()
        {
            Loginn login = new Loginn()
            {
                UserName=userName,
                Password=password
            };
            DataTable dt = loginManage.CheckDataFound(login);
            if (dt.Rows.Count>0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                this.Hide();
                Home home = new Home(userId);
                home.ShowDialog();
                
                
            }
            else
            {
                MessageBox.Show("Data is not found");
            }
        }

        private bool CheckTextBoxNull()
        {
            if (userName.Trim().Equals(String.Empty) || password.Trim().Equals(String.Empty))
            {
                return false;
            }
            return true;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

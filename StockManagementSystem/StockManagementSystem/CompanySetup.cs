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
    public partial class CompanySetup : Form
    {
        int userIdd = 0;
        public CompanySetup(int userId)
        {
            InitializeComponent();
            this.userIdd = userId;
            UpdateButton2.Visible = false;
            this.showCompanyGridView.Columns[1].Visible = false;
            ShowAllData();
        }
        CompanyManage companyManage = new CompanyManage();
        private string companyName = String.Empty;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            companyName = companyTextBox.Text;
            bool checkNull = CheckNullTextBox();
            if (checkNull)
            {
                CheckDuplicateCompany();
            }
            else
            {
                MessageBox.Show("Must fill Company");
            }
            UpdateButton2.Visible = false;
        }

        private void CheckDuplicateCompany()
        {
            Company company = new Company()
            {
                CompanyName = CompanyName
            };
            bool check = companyManage.CheckDuplecateCompany(company);
            if (!check)
            {
                MessageBox.Show("Already Exists This Company");
            }
            else
            {
                Saved(company);
                companyTextBox.Clear();
            }
        }

        private void Saved(Company company)
        {
            int isSaved = companyManage.SaveAll(company);
            if (isSaved > 0)
            {
                addOrUpdate = "Add";
                UserStatusSave(company);
                MessageBox.Show("Saved Successfull");
                ShowAllData();
            }
            else
            {
                MessageBox.Show("Something Wrong into Database");
            }
        }
        string addOrUpdate = String.Empty;
        private void UserStatusSave(Company company)
        {
            UserStatus userStatus = new UserStatus()
            {
                UserId = userIdd,
                ChangeType = addOrUpdate+" " + company.CompanyName + " Company",
                ExecuteTime = DateTime.Now,
            };
            UserStatusManage userStatusManage = new UserStatusManage();
            userStatusManage.SaveUserStatus(userStatus);
        }

        private void ShowAllData()
        {
            showCompanyGridView.ReadOnly = true;
            try
            {
                DataTable dt = companyManage.ShowAllData();
                List<Company> companyList = new List<Company>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        companyList.Add(new Company()
                        {
                            SNo = i + 1,
                            Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                            CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                        });
                    }
                    showCompanyGridView.DataSource = companyList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private bool CheckNullTextBox()
        {
            if (companyName.Trim().Equals(String.Empty))
            {
                return false;
            }
            return true;
        }
        int updateId;
        private void showCompanyGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (showCompanyGridView.Columns[e.ColumnIndex].Name == "UpdateButton")
            {
                companyTextBox.Text = showCompanyGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                updateId = Convert.ToInt32(showCompanyGridView.Rows[e.RowIndex].Cells[1].Value);
                UpdateButton2.Visible = true;
            }
            if (showCompanyGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    int isSaved = companyManage.DeleteCompany(updateId);
                    if (isSaved > 0)
                    {
                        ShowAllData();
                        companyTextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong into Database");
                    }
                }
            }

        }

        private void UpdateButton2_Click(object sender, EventArgs e)
        {
            companyName = companyTextBox.Text;
            bool checkNull = CheckNullTextBox();
            if (checkNull)
            {
                CheckDuplicateCompany(updateId);
            }
            else
            {
                MessageBox.Show("Must fill Company");
            }
        }

        private void CheckDuplicateCompany(int updateId)
        {
            Company company = new Company()
            {
                Id = updateId,
                CompanyName = CompanyName
            };
            bool check = companyManage.CheckDuplecateUpdateCompany(company);
            if (!check)
            {
                MessageBox.Show("Already Exists This Company");
            }
            else
            {
                Update(company);

                companyTextBox.Clear();
            }
        }
        private void Update(Company company)
        {
            int isSaved = companyManage.Update(company);
            if (isSaved > 0)
            {
                addOrUpdate = "Update";
                UserStatusSave(company);
                MessageBox.Show("Update Successfull");
                UpdateButton2.Visible = false;
                ShowAllData();
            }
            else
            {
                MessageBox.Show("Something Wrong into Database");
            }
        }


        private void showCompanyGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                companyTextBox.Text = showCompanyGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                updateId = Convert.ToInt32(showCompanyGridView.Rows[e.RowIndex].Cells[1].Value);
                UpdateButton2.Visible = true;
            }
        }

        private void showCompanyGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.showCompanyGridView.Rows[e.RowIndex].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
        }
    }
}

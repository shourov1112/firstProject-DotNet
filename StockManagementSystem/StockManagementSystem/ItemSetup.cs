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
    public partial class ItemSetup : Form
    {
        int userIdd = 0;
        public ItemSetup(int userId)
        {
            InitializeComponent();
            this.userIdd = userId;
            CategoryFill();
            CompanyFill();
        }
        ItemManage itemManage = new ItemManage();
        string itemName = String.Empty;
        int reorderLevel=0;
        int companyId=0;
        int categoryId=0;
        public void CategoryFill()
        {
            DataTable dt = itemManage.CategoryValue();
            List<Category> categoryList = new List<Category>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    categoryList.Add(new Category()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                        CategoryName = dt.Rows[i]["CategoryName"].ToString(),
                    });
                }
                categoryComboBox.DataSource = categoryList;
            }
        }
        public void CompanyFill()
        {
            DataTable dt = itemManage.CompanyValue();
            List<Company> companyList = new List<Company>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    companyList.Add(new Company()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                        CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    });
                }
                companyComboBox.DataSource = companyList;
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            itemName = itemNameTextBox.Text;
            if (!reorderLevelTextBox.Text.Trim().Equals(String.Empty))
            {
                reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            }
            companyId = Convert.ToInt32(companyComboBox.SelectedValue);
            categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            bool checkTextBox = CheckNullTextBox();
            if (checkTextBox)
            {
                CheckDuplicateItem();
            }
            else
            {
                MessageBox.Show("Must be fill Item Box");
            }
        }

        private void CheckDuplicateItem()
        {
            Item item = new Item()
            {
                ItemName = itemName,
                CompanyId = companyId,
                CategoryId = categoryId,
                ReorderLevel = Convert.ToInt32(reorderLevel),
                Quantity=0
            };
            bool check = itemManage.CheckDuplecateItem(item);
            if (!check)
            {
                MessageBox.Show("Already Exists This Item");
            }
            else
            {
                Saved(item);
                itemNameTextBox.Clear();
            }
        
        }
        private void Saved(Item item)
        {
            int isSaved = itemManage.SaveAll(item);
            if (isSaved > 0)
            {
                UserStatusSave(item);
                MessageBox.Show("Saved Successfull");
            }
            else
            {
                MessageBox.Show("Something Wrong into Database");
            }
        }
        private void UserStatusSave(Item item)
        {
            UserStatus userStatus = new UserStatus()
            {
                UserId = userIdd,
                ChangeType = "Add " + item.ItemName+" Item",
                ExecuteTime = DateTime.Now,
            };
            UserStatusManage userStatusManage = new UserStatusManage();
            userStatusManage.SaveUserStatus(userStatus);
        }
        private bool CheckNullTextBox()
        {
            if (itemName.Trim().Equals(String.Empty) || companyId==0 || categoryId==0)
            {
                return false;
            }
            return true;
        }

      

        private void reorderLevelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;


            }
            else
            {
                e.Handled = false;
            }
        }
        
    }
}

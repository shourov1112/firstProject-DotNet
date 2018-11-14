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
    public partial class StockIn : Form
    {
        int userIdd = 0;
        public StockIn(int userId)
        {
            InitializeComponent();
            this.userIdd = userId;
            CompanyFill();
        }
        StockInManage stockInManage = new StockInManage();
        
        public void CompanyFill()
        {
            DataTable dt = stockInManage.CompanyValue();
            List<Company> companyList = new List<Company>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (i == 0)
                    //{
                    //    takingFirstCompanyId = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                    //}
                    companyList.Add(new Company()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                        CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    });
                }
                companyNameComboBox.DataSource = companyList;
                ItemFill(Convert.ToInt32(companyNameComboBox.SelectedValue));
            }
        }
        List<Item> itemList;
        public void ItemFill(int takingCompanyId)
        {
            DataTable dt = stockInManage.ItemValue(takingCompanyId);
            itemList = new List<Item>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemList.Add(new Item()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        CompanyId =Convert.ToInt32(dt.Rows[i]["CompanyId"]),
                        CategoryId =Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                        ReorderLevel =Convert.ToInt32(dt.Rows[i]["ReorderLevel"]),
                        Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                    });
                }
                //itemNameComboBox.Items.Clear();
                itemNameComboBox.DataSource = itemList;
                ShowToTextLevel(itemList,Convert.ToInt32(itemNameComboBox.SelectedValue));
            }
        }

        private void ShowToTextLevel(List<Item> itemList,int takingItemId)
        {
            var value = itemList.Where(x => x.Id == takingItemId).FirstOrDefault();
              reorderLevelTextBox.Text =value.ReorderLevel.ToString();
              availabeQuantityTextBox.Text = value.Quantity.ToString();
        }
       

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            int reorderLevel = 0;
            try
            {
                quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                if (quantity > 0)
                {
                    SaveQuantity(quantity, reorderLevel);
                }
                else
                {
                    MessageBox.Show(" Must be greater than 0");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fill in integer");
            }
        }

        private void SaveQuantity(int quantity,int reorderLevel)
        {
            var value = itemList.Where(x => x.Id == Convert.ToInt32(itemNameComboBox.SelectedValue)).FirstOrDefault();
            value.Quantity = quantity;
            value.ReorderLevel = reorderLevel;
            bool isSaved = stockInManage.SaveData(value);
            if (isSaved)
            {
                UserStatusSave(value);
                MessageBox.Show("Update Successfull");
               
            }
            else
            {
                MessageBox.Show("Something wrong");
            }
        }
        private void UserStatusSave(Item item)
        {
            UserStatus userStatus = new UserStatus()
            {
                UserId = userIdd,
                ChangeType = "Update " + item.ItemName + " Item",
                ExecuteTime = DateTime.Now,
            };
            UserStatusManage userStatusManage = new UserStatusManage();
            userStatusManage.SaveUserStatus(userStatus);
        }
        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyIdtake =Convert.ToInt32(companyNameComboBox.SelectedValue);
            ItemFill(companyIdtake);
        }

        private void itemNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemIdtake = Convert.ToInt32(itemNameComboBox.SelectedValue);
            ShowToTextLevel(itemList,itemIdtake);
        }

        private void stockInQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;


            }
            else
            {
                if (e.KeyChar >0 && e.KeyChar<=Convert.ToInt32(availabeQuantityTextBox.Text))
                {

                }
                e.Handled = false;
            }
        }
    }
}

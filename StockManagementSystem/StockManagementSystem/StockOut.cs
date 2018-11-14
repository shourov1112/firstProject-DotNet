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
    public partial class StockOut : Form
    {
        public StockOut()
        {
            InitializeComponent();
            addItemDataGridView.ReadOnly = true;
            this.addItemDataGridView.Columns[1].Visible = false;
            this.addItemDataGridView.Columns[2].Visible = false;
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
            reorderLevelTextBox.Text = value.ReorderLevel.ToString();
            availabeQuantityTextBox.Text = value.Quantity.ToString();
        }
        

        private void stockOutQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
        List<StockOutItem> itemAdd = new List<StockOutItem>();
        private void AddButton_Click(object sender, EventArgs e)
        {
            int quantitySelected = 0;
            try
            {
                quantitySelected = Convert.ToInt32(stockOutQuantityTextBox.Text);
                AddedItem(quantitySelected);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Give Quantity in integer");
            }
        }
        int SeNo = 0;
        private void AddedItem(int quantity)
        {
            int availabe = Convert.ToInt32(availabeQuantityTextBox.Text);
            this.addItemDataGridView.DataSource = null;
            if (!(quantity > 0))
            {
                MessageBox.Show("Give quantity");
                return;
            }
            var checkReUse = itemAdd.Where(x => x.ItemId ==Convert.ToInt32(itemNameComboBox.SelectedValue)).FirstOrDefault();
            if (checkReUse!=null)
            {
                if (availabe >=(checkReUse.TotalQuantity+quantity))
                {
                    checkReUse.TotalQuantity = checkReUse.TotalQuantity + quantity;
                }
                else
                {
                    MessageBox.Show("Quantity is not available as you demand");
                }
                
            }
            else
            {
                if (availabe >= quantity)
                {
                    itemAdd.Add(new StockOutItem()
                    {
                        Sno = ++SeNo,
                        CompanyId = Convert.ToInt32(companyNameComboBox.SelectedValue),
                        CompanyName = companyNameComboBox.Text,
                        ItemId = Convert.ToInt32(itemNameComboBox.SelectedValue),
                        ItemName = itemNameComboBox.Text,
                        TotalQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text),
                    });
                }
                else
                {
                    MessageBox.Show("Quantity is not available as you demand");
                }
                
            }
            
            addItemDataGridView.DataSource = itemAdd;
        }

        private void itemNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemIdtake = Convert.ToInt32(itemNameComboBox.SelectedValue);
            ShowToTextLevel(itemList, itemIdtake);
        }


        private void stockOutQuantityTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;


            }
            else
            {
                if (e.KeyChar > 0 && e.KeyChar <= Convert.ToInt32(availabeQuantityTextBox.Text))
                {

                }
                e.Handled = false;
            }
        }

        private void addItemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (addItemDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    int itemIdd = Convert.ToInt32(addItemDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SeNo = 0;
                        var itemValue = itemAdd.Where(x => x.ItemId == itemIdd).FirstOrDefault();
                        itemAdd.Remove(itemValue);
                        ReloadDatagridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select fixed item");
            }
            
        }
        public void ReloadDatagridView()
        {
            this.addItemDataGridView.DataSource = null;
            addItemDataGridView.DataSource = itemAdd;
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyIdtake = Convert.ToInt32(companyNameComboBox.SelectedValue);
            ItemFill(companyIdtake);
        }
        StockOutManage stockOutManage = new StockOutManage();
        private void SellButton_Click(object sender, EventArgs e)
        {
            ItemSellOut("Sell");
        }

        private void ItemSellOut(string sellType)
        {
            if (itemAdd.Count()>0)
            {
                List<int> idList = new List<int>();
                foreach (var value in itemAdd)
                {
                    DataTable dt = CheckAvailableItem(value);
                    if (dt.Rows.Count > 0)
                    {
                        var item = itemList.Where(x => x.Id == value.ItemId).FirstOrDefault();
                        if (item != null)
                        {
                            item.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
                        }
                        idList.Add(value.ItemId);
                        value.SellType = sellType;
                        Saved(value);
                        //itemAdd.Remove(value);
                    }

                }
                foreach (var item in idList)
                {
                    var takeValu = itemAdd.Where(x => x.ItemId == item).FirstOrDefault();
                    itemAdd.Remove(takeValu);
                }
                if (itemAdd.Count() > 0)
                {
                    MessageBox.Show("Some Items Quantity Out of Available Quantity.\n Those items are not saved");

                }
                else
                {
                    MessageBox.Show("Saved successfull");
                }
                CompanyFill();
                ReloadDatagridView();
            }
            else
            {
                MessageBox.Show("Fist add item as your choice");
            }
            
            
        }
        public void Saved(StockOutItem value)
        {
            int isSaved = stockOutManage.Saved(value);
            if (isSaved > 0)
            {
                var takeTotalRemainingItem = itemList.Where(x => x.Id == value.ItemId).FirstOrDefault();
                Item item = new Item()
                {
                    Quantity = takeTotalRemainingItem.Quantity-value.TotalQuantity,
                    Id=value.ItemId
                };
                takeTotalRemainingItem.Quantity = takeTotalRemainingItem.Quantity - value.TotalQuantity;
                ItemManage itemManage = new ItemManage();
                itemManage.UpdateItemQuantity(item);
            }
        }

        private DataTable CheckAvailableItem(StockOutItem value)
        {
            DataTable isSaved = stockOutManage.CheckDuplecateItem(value);
            return isSaved;
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            ItemSellOut("Damage");
        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            ItemSellOut("Lost");
        }

        private void StockOut_Load(object sender, EventArgs e)
        {

        }

        private void addItemDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.addItemDataGridView.Rows[e.RowIndex].Cells["Sno"].Value = (e.RowIndex + 1).ToString();
        }
    }
}

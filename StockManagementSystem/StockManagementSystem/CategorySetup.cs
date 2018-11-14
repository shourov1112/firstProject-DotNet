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
    public partial class CategorySetup : Form
    {
        int userIdd = 0;
        public CategorySetup(int userId)
        {
            InitializeComponent();
            this.userIdd = userId;
            UpdateButton2.Visible = false;
            this.showCategoryGridView.Columns[1].Visible = false;
            ShowAllData();
        }
        CategoryManage categoryManage = new CategoryManage();
        private string categoryName=String.Empty;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            categoryName = categoryTextBox.Text;
            bool checkNull = CheckNullTextBox();
            if (checkNull)
            {
                CheckDuplicateCategory();
            }
            else
            {
                MessageBox.Show("Must fill Category");
            }
            UpdateButton2.Visible = false;
        }

        private void CheckDuplicateCategory()
        {
            Category category = new Category() { 
            CategoryName=categoryName
            };
            bool check = categoryManage.CheckDuplecateCategory(category);
            if (!check)
            {
                MessageBox.Show("Already Exists This Category");
            }
            else
            {
                Saved(category);
                categoryTextBox.Clear();
            }
        }

        private void Saved(Category category)
        {
            int isSaved = categoryManage.SaveAll(category);
            if (isSaved > 0)
            {
                addOrUpdate = "Add";
                UserStatusSave(category);
                MessageBox.Show("Saved Successfull");
                ShowAllData();
            }
            else
            {
                MessageBox.Show("Something Wrong into Database");
            }
        }
        string addOrUpdate = String.Empty;
        private void UserStatusSave(Category category)
        {
            UserStatus userStatus = new UserStatus()
            {
                UserId = userIdd,
                ChangeType = addOrUpdate+" " + category.CategoryName + " Category",
                ExecuteTime = DateTime.Now,
            };
            UserStatusManage userStatusManage = new UserStatusManage();
            userStatusManage.SaveUserStatus(userStatus);
        }
        private void ShowAllData()
        {
            showCategoryGridView.ReadOnly = true;
            try
            {
                DataTable dt = categoryManage.ShowAllData();
                List<Category> categoryList = new List<Category>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        categoryList.Add(new Category()
                        {
                            SNo=i+1,
                            Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                            CategoryName = dt.Rows[i]["CategoryName"].ToString(),
                        });
                    }
                    showCategoryGridView.DataSource = categoryList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
            
        }

        private bool CheckNullTextBox()
        {
            if (categoryName.Trim().Equals(String.Empty))
            {
                return false;
            }
            return true;
        }
        int updateId;
        private void showCategoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (showCategoryGridView.Columns[e.ColumnIndex].Name == "UpdateButton")
            {
                categoryTextBox.Text = showCategoryGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                updateId = Convert.ToInt32(showCategoryGridView.Rows[e.RowIndex].Cells[1].Value);
                UpdateButton2.Visible = true;
            }
            if (showCategoryGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    
                    int isSaved = categoryManage.DeleteCategory(updateId);
                    if (isSaved > 0)
                    {
                        ShowAllData();
                        categoryTextBox.Clear();
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
            categoryName = categoryTextBox.Text;
            bool checkNull = CheckNullTextBox();
            if (checkNull)
            {
                CheckDuplicateCategory(updateId);
            }
            else
            {
                MessageBox.Show("Must fill Category");
            }
        }

        private void CheckDuplicateCategory(int updateId)
        {
            Category category = new Category()
            {
                Id=updateId,
                CategoryName = categoryName
            };
            bool check = categoryManage.CheckDuplecateUpdateCategory(category);
            if (!check)
            {
                MessageBox.Show("Already Exists This Category");
            }
            else
            {
                Update(category);
                categoryTextBox.Clear();
            }
        }
        private void Update(Category category)
        {
            int isSaved = categoryManage.Update(category);
            if (isSaved > 0)
            {
                addOrUpdate = "Update";
                UserStatusSave(category);
                MessageBox.Show("Update Successfull");
                UpdateButton2.Visible = false;
                ShowAllData();
            }
            else
            {
                MessageBox.Show("Something Wrong into Database");
            }
        }

        
        private void showCategoryGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                categoryTextBox.Text = showCategoryGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                updateId = Convert.ToInt32(showCategoryGridView.Rows[e.RowIndex].Cells[1].Value);
                UpdateButton2.Visible = true;
            }
        }

        private void showCategoryGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.showCategoryGridView.Rows[e.RowIndex].Cells["SNo"].Value = (e.RowIndex + 1).ToString();
        }
    }
}

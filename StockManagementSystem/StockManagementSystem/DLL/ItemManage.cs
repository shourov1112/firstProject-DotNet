using StockManagementSystem.DAL;
using StockManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DLL
{
    public class ItemManage
    {
        DBItemRepository _dbItemRepository = new DBItemRepository();
        internal bool CheckDuplecateItem(Item item)
        {
            string query = @"SELECT * FROM tblItem WHERE ItemName='" + item.ItemName + "'";
            DataTable dt = _dbItemRepository.CheckAll(query);
            if (dt.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }
        internal System.Data.DataTable CategoryValue()
        {
            string query = @"SELECT * FROM tblCategory";
            DataTable dt = _dbItemRepository.CategoryOrCompanyValue(query);
            return dt;
        }

        internal DataTable CompanyValue()
        {
            string query = @"SELECT * FROM tblCompany";
            DataTable dt = _dbItemRepository.CategoryOrCompanyValue(query);
            return dt;
        }

        internal int SaveAll(Item item)
        {
            string query = @"INSERT INTO tblItem (ItemName,ReorderLevel,CompanyId,CategoryId,Quantity) VALUES('" + item.ItemName + "','"+item.ReorderLevel+"','"+item.CompanyId+"','"+item.CategoryId+"','"+item.Quantity+"')";
            int rowCount = _dbItemRepository.SaveOrDelete(query);
            return rowCount;
        }

        internal void UpdateItemQuantity(Item item)
        {
            string query = @"UPDATE tblItem SET Quantity='" + item.Quantity + "' WHERE Id='"+item.Id+"'";
            int rowCount = _dbItemRepository.SaveOrDelete(query);
        }
    }
}

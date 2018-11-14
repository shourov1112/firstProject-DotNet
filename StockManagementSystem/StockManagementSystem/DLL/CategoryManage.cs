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
    public class CategoryManage
    {
        static DBRepository _dbRepository = new DBRepository();
        internal bool CheckDuplecateCategory(Model.Category category)
        {
            string query = @"SELECT * FROM tblCategory WHERE CategoryName='"+category.CategoryName+"'";
            DataTable dt = _dbRepository.CheckAll(query);
            if (dt.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }
        internal bool CheckDuplecateUpdateCategory(Model.Category category)
        {
            string query = @"SELECT * FROM tblCategory WHERE CategoryName='" + category.CategoryName + "' AND Id!='"+category.Id+"'";
            DataTable dt = _dbRepository.CheckAll(query);
            if (dt.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }

        internal int SaveAll(Model.Category category)
        {
            string query = @"INSERT INTO tblCategory (CategoryName) VALUES('" + category.CategoryName + "')";
            int rowCount = _dbRepository.SaveOrDelete(query);
            return rowCount;
        }

        internal DataTable ShowAllData()
        {
            string query = @"SELECT * FROM tblCategory";
            DataTable dt = _dbRepository.CheckAll(query);
            return dt;
        }

        internal int DeleteCategory(int p)
        {
            string query = @"DELETE FROM tblCategory WHERE Id='"+p+"'";
            int rowCount = _dbRepository.SaveOrDelete(query);
            return rowCount;
        }
        internal int Update(Category category)
        {
            string query = @"UPDATE tblCategory set CategoryName='"+category.CategoryName+"' WHERE Id='"+category.Id+"'";
            int rowCount = _dbRepository.SaveOrDelete(query);
            return rowCount;
        }
    }
}

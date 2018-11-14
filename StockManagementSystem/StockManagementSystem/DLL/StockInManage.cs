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
    public class StockInManage
    {
        DBStockInRepository _dbStockInRepository = new DBStockInRepository();
        internal System.Data.DataTable CompanyValue()
        {
            string query = @"SELECT * FROM tblCompany";
            DataTable dt = _dbStockInRepository.ItemOrCompanyValue(query);
            return dt;
        }

        internal DataTable ItemValue(int takingCompanyId)
        {
            string query = @"SELECT * FROM tblItem WHERE CompanyId='"+takingCompanyId+"'";
            DataTable dt = _dbStockInRepository.ItemOrCompanyValue(query);
            return dt;
        }

        internal bool SaveData(Item item)
        {
            string query = @"UPDATE tblItem set Quantity='"+item.Quantity+"',ReorderLevel='"+item.ReorderLevel+"' WHERE Id='"+item.Id+"'";
            int rowCount = _dbStockInRepository.SaveData(query);
            return true;
        }
    }
}

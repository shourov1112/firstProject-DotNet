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
    public class StockOutManage
    {
        DBStockOutRepository _dbStockOutRepository = new DBStockOutRepository();

        internal DataTable CheckDuplecateItem(StockOutItem item)
        {
            string query = @"SELECT * FROM tblItem WHERE Id='" + item.ItemId + "' AND ReorderLevel<='"+item.TotalQuantity+"'";
            DataTable dt = _dbStockOutRepository.CheckAll(query);
           return dt;
        }
        internal int Saved(StockOutItem value)
        {
            string query = @"INSERT INTO tblSell (ItemId,CompanyId,QuantityTotal,SellType,SellDate) VALUES('" + value.ItemId + "','" + value.CompanyId + "','" + value.TotalQuantity + "','"+value.SellType+"','" + DateTime.Now + "')";
            int rowCount = _dbStockOutRepository.Saved(query);
            return rowCount;
        }
        
    }
}

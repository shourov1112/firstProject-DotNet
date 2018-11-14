using StockManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DLL
{
    public class SearchItemManage
    {
        DBSearchRepository _dbSearchRepository = new DBSearchRepository();
        internal System.Data.DataTable CategoryValue(int companyId)
        {
            string query = @"SELECT ca.CategoryName,ca.Id,i.ItemName,c.CompanyName,i.ReorderLevel,i.Quantity FROM tblItem i
                            INNER JOIN tblCompany c ON i.CompanyId=c.Id
                            INNER JOIN tblCategory ca ON i.CategoryId=ca.Id where c.Id='"+companyId+"'";
            DataTable dt = _dbSearchRepository.CategoryOrCompanyValue(query);
            return dt;
        }

        internal System.Data.DataTable CompanyValue()
        {
            string query = @"SELECT * FROM tblCompany";
            DataTable dt = _dbSearchRepository.CategoryOrCompanyValue(query);
            return dt;
        }

       

        internal DataTable SellQuantity(DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT i.ItemName,SUM(s.QuantityTotal) as QuantityTotal FROM tblSell s INNER JOIN tblItem i ON i.Id=s.ItemId WHERE SellDate>='" + fromDate + "' AND SellDate<='" + toDate + "' Group by i.ItemName ";
            DataTable dt = _dbSearchRepository.CategoryOrCompanyValue(query);
            return dt;
        }
    }
}

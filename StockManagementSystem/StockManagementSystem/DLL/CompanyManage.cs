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
    public class CompanyManage
    {
        static DBCompanyRepository _dbCompanRepository = new DBCompanyRepository();
        internal bool CheckDuplecateCompany(Model.Company company)
        {
            string query = @"SELECT * FROM tblCompany WHERE CompanyName='" + company.CompanyName + "'";
            DataTable dt = _dbCompanRepository.CheckAll(query);
            if (dt.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }
        internal bool CheckDuplecateUpdateCompany(Model.Company company)
        {
            string query = @"SELECT * FROM tblCompany WHERE CompanyName='" + company.CompanyName + "' AND Id!='" + company.Id + "'";
            DataTable dt = _dbCompanRepository.CheckAll(query);
            if (dt.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }

        internal int SaveAll(Model.Company company)
        {
            string query = @"INSERT INTO tblCompany (CompanyName) VALUES('" + company.CompanyName + "')";
            int rowCount = _dbCompanRepository.SaveOrDelete(query);
            return rowCount;
        }

        internal DataTable ShowAllData()
        {
            string query = @"SELECT * FROM tblCompany";
            DataTable dt = _dbCompanRepository.CheckAll(query);
            return dt;
        }

        internal int DeleteCompany(int p)
        {
            string query = @"DELETE FROM tblCompany WHERE Id='" + p + "'";
            int rowCount = _dbCompanRepository.SaveOrDelete(query);
            return rowCount;
        }
        internal int Update(Company company)
        {
            string query = @"UPDATE tblCompany set CompanyName='" + company.CompanyName + "' WHERE Id='" + company.Id + "'";
            int rowCount = _dbCompanRepository.SaveOrDelete(query);
            return rowCount;
        }
    }
}

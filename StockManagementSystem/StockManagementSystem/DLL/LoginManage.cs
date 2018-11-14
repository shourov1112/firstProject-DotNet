using StockManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DLL
{
    public class LoginManage
    {
        DBLoginRepository _dbLoginRepository = new DBLoginRepository();
        internal DataTable CheckDataFound(Model.Loginn login)
        {
            string query = @"SELECT * FROM tblLogin WHERE UserName='"+login.UserName+"' AND Password='"+login.Password+"'";

            DataTable dt = _dbLoginRepository.CheckDataFound(query);
            return dt;
        }
    }
}

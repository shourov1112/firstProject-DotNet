using StockManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DLL
{
    public class UserStatusManage
    {
        DBUserStatusRepository _dbUserStatusRepostory = new DBUserStatusRepository();
        internal bool SaveUserStatus(Model.UserStatus userStatus)
        {string query = @"INSERT INTO tblSaveUserInfo (UserId,ChangeType,ExecuteTime) VALUES('" + userStatus.UserId + "','" + userStatus.ChangeType + "','" + DateTime.Now + "')";
           int rowCount= _dbUserStatusRepostory.SaveUserStatus(query);
           if (rowCount > 0)
           {
               return true;
           }
           return false;
        }

        internal System.Data.DataTable ShowAllData()
        {
            string query = @"SELECT l.Name,s.ChangeType as Operation,s.ExecuteTime as Time FROM tblSaveUserInfo s INNER JOIN tblLogin l ON l.Id=s.UserId";
            DataTable dt = _dbUserStatusRepostory.ShowAllData(query);
            return dt;
        }
    }
}

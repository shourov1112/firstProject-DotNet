using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DAL
{
    
    public class DBLoginRepository
    {

        static string conString = "Server=FARIAN-PC; Database=StockManagement; Integrated Security=true";
        SqlConnection con = new SqlConnection(conString);


        internal System.Data.DataTable CheckDataFound(string query)
        {
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();

            return dt;
        }
    }
}

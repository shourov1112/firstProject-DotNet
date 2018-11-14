using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.DAL
{
    public class DBRepository
    {
        static string conString = "Server=FARIAN-PC; Database=StockManagement; Integrated Security=true"; 
        SqlConnection con = new SqlConnection(conString);
        internal DataTable CheckAll(string query)
        {
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            //SqlDataReader dr = command.ExecuteReader(); 
            con.Close();


            return dt;
        }
        internal int SaveOrDelete(string query)
        {
            SqlCommand command = new SqlCommand(query, con);
            con.Open(); 
            int rowCount = command.ExecuteNonQuery(); 
            con.Close();
            return rowCount;
        }
    }
}

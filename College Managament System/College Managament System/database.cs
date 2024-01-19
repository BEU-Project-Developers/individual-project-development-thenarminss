using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managament_System
{
    public class DatabaseContext
    {
        private readonly string connectionString = "Data Source=DESKTOP-6D1L7JD;" + "Initial Catalog=master;" + "Integrated Security=SSPI;";

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

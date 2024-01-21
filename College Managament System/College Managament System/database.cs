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
        // Connection string for the database
        private readonly string connectionString = "Data Source=DESKTOP-6D1L7JD;" + "Initial Catalog=master;" + "Integrated Security=SSPI;";

        // Execute a SQL query and return the result as a DataTable
        public DataTable ExecuteQuery(string query)
        {
            // Using statement ensures that resources are properly disposed
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    con.Open();

                    // SqlDataAdapter to fill a DataTable with the results of the query
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);

                    // DataTable to hold the result set
                    DataTable table = new DataTable();

                    // Fill the DataTable with the data from the query
                    dataAdapter.Fill(table);

                    // Return the DataTable
                    return table;
                }
                catch (Exception ex)
                {
                    // Throw the exception if an error occurs
                    throw ex;
                }
            }
        }

        // Execute a non-query SQL command (e.g., insert, update, delete)
        public int ExecuteNonQuery(string query)
        {
            // Using statement ensures that resources are properly disposed
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    con.Open();

                    // SqlCommand to execute the non-query command
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Execute the non-query command and return the number of affected rows
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Throw the exception if an error occurs
                    throw ex;
                }
            }
        }
    }
}

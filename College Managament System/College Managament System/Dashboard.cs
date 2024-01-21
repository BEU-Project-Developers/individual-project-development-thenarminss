using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace College_Managament_System
{
    public partial class Dashboard : Form
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            // Close the application when the close button is clicked
            Application.Exit();
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Query to get the count of students in the StudentTable
                string query = "select count(*) from StudentTable";
                DataTable dt1 = dbContext.ExecuteQuery(query);

                // Display the count of students in Label5
                Label5.Text = dt1.Rows[0][0].ToString();

                // Query to get the count of records in the FeesTable and calculate the total fees
                string query1 = "select count(*) from FeesTable";
                DataTable dt2 = dbContext.ExecuteQuery(query1);
                Label7.Text = "Rs" + Convert.ToInt32(dt2.Rows[0][0].ToString()) * 25000;

                // Query to get the count of teachers in the TeacherTable
                string query2 = "select count(*) from TeacherTable";
                DataTable dt3 = dbContext.ExecuteQuery(query2);

                // Display the count of teachers in Label6
                Label6.Text = dt3.Rows[0][0].ToString();

                // Query to get the count of departments in the DepartmentTable
                string query3 = "select count(*) from DepartmentTable";
                DataTable dt4 = dbContext.ExecuteQuery(query3);

                // Display the count of departments in Label8
                Label8.Text = dt4.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an error message
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}



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
            Application.Exit();
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            try
            {
                string query = "select count(*) from StudentTable";
                DataTable dt1 = dbContext.ExecuteQuery(query);
                Label5.Text = dt1.Rows[0][0].ToString();

                string query1 = "select count(*) from FeesTable";
                DataTable dt2 = dbContext.ExecuteQuery(query1);
                Label7.Text = "Rs" + Convert.ToInt32(dt2.Rows[0][0].ToString()) * 25000;

                string query2 = "select count(*) from TeacherTable";
                DataTable dt3 = dbContext.ExecuteQuery(query2);
                Label6.Text = dt3.Rows[0][0].ToString();

                string query3 = "select count(*) from DepartmentTable";
                DataTable dt4 = dbContext.ExecuteQuery(query3);
                Label8.Text = dt4.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }

}


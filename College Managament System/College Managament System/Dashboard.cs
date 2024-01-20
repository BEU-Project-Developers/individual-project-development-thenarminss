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
            string query = "select count (*) from StudentTable";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            sda1.Fill(dt1);
            Label5.Text = dt1.Rows[0][0].ToString();
            string query1 = "select count (*) from FeesTable";
            SqlCommand cmd1 = new SqlCommand(query1);
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd1);
            sda2.Fill(dt2);
            Label7.Text = "Rs" + Convert.ToInt32(dt2.Rows[0][0].ToString()) * 25000;
            string query2 = "select count (*) from TeacherTable";
            SqlCommand cmd2 = new SqlCommand(query2);
            DataTable dt3 = new DataTable();
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd2);
            sda1.Fill(dt3);
            Label6.Text = dt3.Rows[0][0].ToString();
            string query3 = "select count (*) from DepartmentTable";
            SqlCommand cmd3 = new SqlCommand(query2);
            DataTable dt4 = new DataTable();
            SqlDataAdapter sda4 = new SqlDataAdapter(cmd3);
            sda1.Fill(dt4);
            Label8.Text = dt4.Rows[0][0].ToString();
        }
    }

}


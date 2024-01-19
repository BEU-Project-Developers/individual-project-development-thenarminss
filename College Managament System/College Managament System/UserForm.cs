using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;
namespace College_Managament_System
{
    public partial class UserForm : Form
    {
        private readonly DatabaseContext dbContext = new DatabaseContext(); 
        public UserForm()
        {
            InitializeComponent();
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\dbCMS.mdf;Integrated Security=True");
        private void UserForm_Load(object sender, EventArgs e)
        {
            populate();


            
            
        }
       
        private void populate()
        {
            string query = "select * from UserTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            Userguna2DataGridView.DataSource = dataTable;
        }

        private void UIDguna2TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void UNameguna2TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void UPasswguna2TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UIDguna2TextBox.Text == "" || UNameguna2TextBox.Text == "" || UPasswguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    //Con.Open();
                    string query = $"insert into UserTable values( '{ UIDguna2TextBox.Text }','{ UNameguna2TextBox.Text }', '{ UPasswguna2TextBox.Text }')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Successfully Added");
                    //Con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }
    }
}

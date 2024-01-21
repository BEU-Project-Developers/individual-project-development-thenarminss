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
using Guna.UI2.WinForms;
namespace College_Managament_System
{
    public partial class login : Form
    {
        // DatabaseContext instance for executing queries
        private readonly DatabaseContext dbContext = new DatabaseContext();

        // Constructor for initializing the login form
        public login()
        {
            InitializeComponent();
        }
        private void LoginPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Paint event for LoginPanel1 (empty in this case)
        }
        private void login_Load(object sender, EventArgs e)
        {
            // Load event for the login form (empty in this case)
        }

        // TextChanged event for UserNameTextBox (empty in this case)
        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // TextChanged event for UserNameTextBox (empty in this case)
        }
        private void LoginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // CheckedChanged event for LoginCheckBox (empty in this case)
        }

        // Click event for Button1 (Login button)
        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Creating an instance of the Mainform
                Mainform Home = new Mainform();

                // Query to check if the entered username and password exist in UserTable
                string query = $"select count(*) from UserTable where UserName = '{UserNameTextBox.Text}' and Password = '{PasswordTextBox.Text}'";

                // Execute the query and get the result into a DataTable
                DataTable dt = dbContext.ExecuteQuery(query);

                // If there is at least one row in the result and the count is 1, open the Mainform
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                {
                    Home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void Label2_Click_1(object sender, EventArgs e)
        {
            // Click event for Label2 (empty in this case)
        }
        private void PasswordTextBox_TextChanged_1(object sender, EventArgs e)
        {
            // TextChanged event for PasswordTextBox (empty in this case)
        }
        private void LoginPanel2_Paint_1(object sender, PaintEventArgs e)
        {
            // Paint event for LoginPanel2 (empty in this case)
        }
    }
}

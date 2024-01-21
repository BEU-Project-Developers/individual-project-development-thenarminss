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
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public login()
        {
            InitializeComponent();
        }

        private void LoginPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void login_Load(object sender, EventArgs e)
        {

        }
        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoginCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            //Mainform Mform = new Mainform();
            //Mform.Show();
            //this.Hide();
            try
            {
                Mainform Home = new Mainform();
                string query = $"select count(*) from UserTable where UserName = '{ UserNameTextBox.Text}' and Password = '{PasswordTextBox.Text}'";
                DataTable dt = dbContext.ExecuteQuery(query);

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

        }

        private void PasswordTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void LoginPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

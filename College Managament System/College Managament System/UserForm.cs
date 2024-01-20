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
            UserDGV.DataSource = dataTable;

        }

        private void UIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void UNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void UPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void Button4_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UIdTextBox.Text == "" || UNameTextBox.Text == "" || UPasswordTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    string query = $"insert into UserTable values( '{UIdTextBox.Text}','{UNameTextBox.Text}', '{UPasswordTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Successfully Added");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UIdTextBox.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            UNameTextBox.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UPasswordTextBox.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UIdTextBox.Text == "")
                {
                    MessageBox.Show("Enter The User Id");
                }
                else
                {

                    string query = $"delete from UserTable where UserId = ( '{UIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Deleted Successfuly");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... User Not Deleted");
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UIdTextBox.Text == "" || UNameTextBox.Text == "" || UPasswordTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update UserTable set UserName = ('{UNameTextBox.Text}'), password = ('{UPasswordTextBox.Text}') where UserId = ('{UIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Updated Successfully");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... User Not Updated");
            }
        }
    }
}

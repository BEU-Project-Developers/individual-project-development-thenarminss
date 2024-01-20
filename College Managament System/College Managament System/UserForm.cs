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
        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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
                    string query = $"insert into UserTable values( '{UIDguna2TextBox.Text}','{UNameguna2TextBox.Text}', '{UPasswguna2TextBox.Text}')";
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

        private void Userguna2DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UIDguna2TextBox.Text = Userguna2DataGridView.SelectedRows[0].Cells[0].Value.ToString();
            UNameguna2TextBox.Text = Userguna2DataGridView.SelectedRows[0].Cells[1].Value.ToString();
            UPasswguna2TextBox.Text = Userguna2DataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2HtmlLabel7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UIDguna2TextBox.Text == "")
                {
                    MessageBox.Show("Enter The User Id");
                }
                else
                {

                    string query = $"delete from UserTable where UserId = ( '{UIDguna2TextBox.Text}')";
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

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UIDguna2TextBox.Text == "" || UNameguna2TextBox.Text == "" || UPasswguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update UserTable set UserName = ('{UNameguna2TextBox.Text}'), password = ('{UPasswguna2TextBox.Text}') where UserId = ('{UIDguna2TextBox.Text}')";
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

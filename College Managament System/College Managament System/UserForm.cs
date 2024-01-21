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
            // Load initial data when the form is loaded
            populate();
        }

        private void populate()
        {
            // Fetch all records from the UserTable and display them in the DataGridView
            string query = "select * from UserTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            UserDGV.DataSource = dataTable;
        }

        private void UIdTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle any event logic related to UIdTextBox_TextChanged if needed
        }

        private void UNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle any event logic related to UNameTextBox_TextChanged if needed
        }

        private void UPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle any event logic related to UPasswordTextBox_TextChanged if needed
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Navigate back to the Mainform when Button4 is clicked
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check for missing information before inserting a new user
                if (UIdTextBox.Text == "" || UNameTextBox.Text == "" || UPasswordTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    // Insert a new user into the UserTable
                    string query = $"insert into UserTable values( '{UIdTextBox.Text}','{UNameTextBox.Text}', '{UPasswordTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Successfully Added");
                    // Refresh the DataGridView with updated data
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
            // Fill textboxes with selected user's information when a cell is clicked
            UIdTextBox.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            UNameTextBox.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UPasswordTextBox.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Label6_Click_1(object sender, EventArgs e)
        {
            // Close the application when Label6 is clicked
            Application.Exit();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check for missing information before deleting a user
                if (UIdTextBox.Text == "")
                {
                    MessageBox.Show("Enter The User Id");
                }
                else
                {
                    // Delete the selected user from the UserTable
                    string query = $"delete from UserTable where UserId = ( '{UIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Deleted Successfully");
                    // Refresh the DataGridView with updated data
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
                // Check for missing information before updating a user
                if (UIdTextBox.Text == "" || UNameTextBox.Text == "" || UPasswordTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    // Update the selected user's information in the UserTable
                    string query = $"update UserTable set UserName = ('{UNameTextBox.Text}'), password = ('{UPasswordTextBox.Text}') where UserId = ('{UIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("User Updated Successfully");
                    // Refresh the DataGridView with updated data
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


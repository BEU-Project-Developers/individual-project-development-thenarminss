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
    public partial class Department : Form
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();

        public Department()
        {
            InitializeComponent();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            // Load initial data when the form is loaded
            populate();
        }

        private void populate()
        {
            // Fetch all records from the DepartmentTable and display them in the DataGridView
            string query = "select * from DepartmentTable";

            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            DepDGV.DataSource = dataTable;
        }

        private void DepPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Handle any painting logic if needed
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check for missing data before inserting a new department
                if (DepNameguna2TextBox.Text == "" || DepDescriptionguna2TextBox.Text == "" || DepDurationguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    // Insert a new department into the DepartmentTable
                    string query = $"insert into DepartmentTable values( '{DepNameguna2TextBox.Text}','{DepDescriptionguna2TextBox.Text}', '{DepDurationguna2TextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Department Successfully Added");
                    // Refresh the DataGridView with updated data
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            // Close the application when Label6 is clicked
            Application.Exit();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check for missing data before updating a department
                if (DepNameguna2TextBox.Text == "" || DepDescriptionguna2TextBox.Text == "" || DepDurationguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    // Update the selected department's information in the DepartmentTable
                    string query = $"update DepartmentTable set DepDesc = ('{DepDescriptionguna2TextBox.Text}'), DepDuration = ('{DepDurationguna2TextBox.Text}') where DepName = ('{DepNameguna2TextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Department Updated Successfully");
                    // Refresh the DataGridView with updated data
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Department Not Updated");
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check for missing data before deleting a department
                if (DepNameguna2TextBox.Text == "")
                {
                    MessageBox.Show("Enter The Department Name");
                }
                else
                {
                    // Delete the selected department from the DepartmentTable
                    string query = $"delete from DepartmentTable where DepName = ( '{DepNameguna2TextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Department Deleted Successfully");
                    // Refresh the DataGridView with updated data
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Department Not Deleted");
            }
        }

        private void DepDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Fill textboxes with selected department's information when a cell is clicked
            DepNameguna2TextBox.Text = DepDGV.SelectedRows[0].Cells[0].Value.ToString();
            DepDescriptionguna2TextBox.Text = DepDGV.SelectedRows[0].Cells[1].Value.ToString();
            DepDurationguna2TextBox.Text = DepDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            // Navigate back to the Mainform when Button4 is clicked
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
    }
}


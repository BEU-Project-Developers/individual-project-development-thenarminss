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
    public partial class Teacher : Form
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();

        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            // Fill the department combo box when the form is loaded
            fillDepartment();
            // Load initial data when the form is loaded
            populate();
        }

        private void fillDepartment()
        {
            // Fetch department names from the DepartmentTable and fill the combo box
            string query = "select DepName from DepartmentTable";
            var dataTable = dbContext.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DepComboBox.ValueMember = "DepName";
                DepComboBox.DataSource = dataTable;
            }
            else
            {
                // Handle the case when there is no data in the DepartmentTable
                MessageBox.Show("No departments found.");
            }
        }

        private void populate()
        {
            // Fetch all records from the TeacherTable and display them in the DataGridView
            string query = "select * from TeacherTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            TeacherDGV.DataSource = dataTable;
        }

        private void panel1_Paint(object sender, EventArgs e)
        {
            // Handle any painting logic if needed
        }

        private void TeacherDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Handle any specific logic when the TeacherDateTimePicker value changes
        }

        private void DepComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle any specific logic when the DepComboBox selected index changes
        }

        private void TeacherPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle any specific logic when the TeacherPhoneTextBox text changes
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for missing data before inserting a new teacher
                if (TeacherIdTextBox.Text == "" || TeacherNameTextBox.Text == "" || TeacherAddressTextBox.Text == "" || TeacherPhoneTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    // Insert a new teacher into the TeacherTable
                    string query = $"insert into TeacherTable values( '{TeacherIdTextBox.Text}','{TeacherNameTextBox.Text}', '{GenderComboBox.SelectedItem.ToString()}','{TeacherDateTimePicker.Text}','{TeacherPhoneTextBox.Text}', '{DepComboBox.SelectedValue.ToString()}' , '{TeacherAddressTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Teacher Successfully Added");
                    // Refresh the DataGridView with updated data
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for missing data before updating a teacher
                if (TeacherIdTextBox.Text == "" || TeacherNameTextBox.Text == "" || TeacherAddressTextBox.Text == "" || TeacherPhoneTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    // Update the selected teacher's information in the TeacherTable
                    string query = $"update TeacherTable set TeacherName = ('{TeacherNameTextBox.Text}'), TeacherGender = ('{GenderComboBox.SelectedItem.ToString()} ') ,TeacherDOB = ('{TeacherDateTimePicker.Text}'), TeacherPhone =  (' {TeacherPhoneTextBox.Text} ') , TeacherDep = ('{DepComboBox.SelectedValue.ToString()}') , TeacherAdd =('{TeacherAddressTextBox.Text}') where TeacherId = ('{TeacherIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Teacher Updated Successfully");
                    // Refresh the DataGridView with updated data
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Teacher Not Updated");
            }
        }

        private void TeacherDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Fill textboxes with selected teacher's information when a cell is clicked
            TeacherIdTextBox.Text = TeacherDGV.SelectedRows[0].Cells[0].Value.ToString();
            TeacherNameTextBox.Text = TeacherDGV.SelectedRows[0].Cells[1].Value.ToString();
            GenderComboBox.SelectedItem = TeacherDGV.SelectedRows[0].Cells[2].Value.ToString();
            TeacherPhoneTextBox.Text = TeacherDGV.SelectedRows[0].Cells[4].Value.ToString();
            TeacherAddressTextBox.Text = TeacherDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for missing data before deleting a teacher
                if (TeacherIdTextBox.Text == "")
                {
                    MessageBox.Show("Enter The Teacher's Id");
                }
                else
                {
                    // Delete the selected teacher from the TeacherTable
                    string query = $"delete from TeacherTable where TeacherId = ( '{TeacherIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Teacher Deleted Successfully");
                    // Refresh the DataGridView with updated data
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Teacher Not Deleted");
            }
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            // Close the application when Label10 is clicked
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Navigate back to the Mainform when Button4 is clicked
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
    }
}



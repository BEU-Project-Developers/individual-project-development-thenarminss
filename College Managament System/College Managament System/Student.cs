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
    public partial class Student : Form
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public Student()
        {
            InitializeComponent();
        }
        private void Student_Load(object sender, EventArgs e)
        {
            fillDepartment();
            populate();
        }
        private void fillDepartment()
        {
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
            string query = "select * from StudentTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            StdDGV.DataSource = dataTable;

        }
        private void noduelist()
        {
            string query = "select * from StudentTable where StdFees > ( '{0}')";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            StdDGV.DataSource = dataTable;

        }

        private void StdDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Label10_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (StdIdTextBox.Text == "" || StdNameTextBox.Text == "" || StdFeesTextBox.Text == "" || StdPhoneTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update StudentTable set StdName = '{StdNameTextBox.Text}', StdGender = '{GenderComboBox.SelectedItem.ToString()}', StdDOB = '{StdDateTimePicker.Text}', StdPhone = '{StdPhoneTextBox.Text}', StdDep = '{DepComboBox.SelectedValue.ToString()}', StdFees = '{StdFeesTextBox.Text}' where StdId = '{StdIdTextBox.Text}'";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Student Updated Successfully");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Student Not Updated");
            }
        }


        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (StdIdTextBox.Text == "")
                {
                    MessageBox.Show("Enter The Student's Id");
                }
                else
                {
                    string query = $"delete from StudentTable where StdId = ( '{StdIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Student Deleted Successfuly");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Student Not Deleted");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void StdDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            StdIdTextBox.Text = StdDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdNameTextBox.Text = StdDGV.SelectedRows[0].Cells[1].Value.ToString();
            GenderComboBox.SelectedItem = StdDGV.SelectedRows[0].Cells[2].Value.ToString();
            StdPhoneTextBox.Text = StdDGV.SelectedRows[0].Cells[4].Value.ToString();
            StdFeesTextBox.Text = StdDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (StdIdTextBox.Text == "" || StdNameTextBox.Text == "" || StdPhoneTextBox.Text == "" || StdFeesTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"insert into StudentTable values( '{StdIdTextBox.Text}','{StdNameTextBox.Text}', '{GenderComboBox.SelectedItem.ToString()}','{StdDateTimePicker.Text}','{StdPhoneTextBox.Text}', '{DepComboBox.SelectedValue.ToString()}' , '{StdFeesTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Student Successfully Added");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            noduelist();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}


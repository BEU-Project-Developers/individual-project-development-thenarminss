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
                guna2ComboBox2.ValueMember = "DepName";
                guna2ComboBox2.DataSource = dataTable;
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
            Studentguna2DataGridView.DataSource = dataTable;

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void guna2Button2_Click1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (SIDguna2TextBox.Text == "" || SNameguna2TextBox.Text == "" || SFeeguna2TextBox.Text == "" || SPhoneguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update StudentTable set StdName = '{SNameguna2TextBox.Text}', StdGender = '{guna2ComboBox1.SelectedItem.ToString()}', StdDOB = '{guna2DateTimePicker1.Text}', StdPhone = '{SPhoneguna2TextBox.Text}', StdDep = '{guna2ComboBox2.SelectedValue.ToString()}', StdFees = '{SFeeguna2TextBox.Text}' where StdId = '{SIDguna2TextBox.Text}'";
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


        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (SIDguna2TextBox.Text == "")
                {
                    MessageBox.Show("Enter The Student's Id");
                }
                else
                {
                    string query = $"delete from StudentTable where StdId = ( '{SIDguna2TextBox.Text}')";
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void Studentguna2DataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SIDguna2TextBox.Text = Studentguna2DataGridView.SelectedRows[0].Cells[0].Value.ToString();
            SNameguna2TextBox.Text = Studentguna2DataGridView.SelectedRows[0].Cells[1].Value.ToString();
            guna2ComboBox1.SelectedItem = Studentguna2DataGridView.SelectedRows[0].Cells[2].Value.ToString();
            SPhoneguna2TextBox.Text = Studentguna2DataGridView.SelectedRows[0].Cells[4].Value.ToString();
            SFeeguna2TextBox.Text = Studentguna2DataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (SIDguna2TextBox.Text == "" || SNameguna2TextBox.Text == "" || SPhoneguna2TextBox.Text == "" || SFeeguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"insert into StudentTable values( '{SIDguna2TextBox.Text}','{SNameguna2TextBox.Text}', '{guna2ComboBox1.SelectedItem.ToString()}','{guna2DateTimePicker1.Text}','{SPhoneguna2TextBox.Text}', '{guna2ComboBox2.SelectedValue.ToString()}' , '{SFeeguna2TextBox.Text}')";
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
    }
}


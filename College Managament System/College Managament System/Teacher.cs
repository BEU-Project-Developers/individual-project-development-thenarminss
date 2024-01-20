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
            string query = "select * from TeacherTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            TeacherDGV.DataSource = dataTable;

        }

        private void panel1_Paint(object sender, EventArgs e)
        {

        }

        private void TeacherDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DepComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TeacherPhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TeacherIdTextBox.Text == "" || TeacherNameTextBox.Text == "" || TeacherAddressTextBox.Text == "" || TeacherPhoneTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"insert into TeacherTable values( '{TeacherIdTextBox.Text}','{TeacherNameTextBox.Text}', '{GenderComboBox.SelectedItem.ToString()}','{TeacherDateTimePicker.Text}','{TeacherPhoneTextBox.Text}', '{DepComboBox.SelectedValue.ToString()}' , '{TeacherAddressTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Teacher Successfully Added");
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
                if (TeacherIdTextBox.Text == "" || TeacherNameTextBox.Text == "" || TeacherAddressTextBox.Text == "" || TeacherPhoneTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update TeacherTable set TeacherName = ('{TeacherNameTextBox.Text}'), TeacherGender = ('{GenderComboBox.SelectedItem.ToString()} ') ,TeacherDOB = ('{TeacherDateTimePicker.Text}'), TeacherPhone =  (' {TeacherPhoneTextBox.Text} ') , TeacherDep = ('{DepComboBox.SelectedValue.ToString()}') , TeacherAdd =('{TeacherAddressTextBox.Text}') where TeacherId = ('{TeacherIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Teacher Updated Successfully");
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
                if (TeacherIdTextBox.Text == "")
                {
                    MessageBox.Show("Enter The Teacher's Id");
                }
                else
                {
                    string query = $"delete from TeacherTable where TeacherId = ( '{TeacherIdTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Teacher Deleted Successfuly");
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
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
    }
}


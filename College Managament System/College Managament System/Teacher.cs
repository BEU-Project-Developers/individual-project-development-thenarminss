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
            string query = "select * from TeacherTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            Teacherguna2DataGridView.DataSource = dataTable;

        }

        private void panel1_Paint(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TIDguna2TextBox.Text == "" || TNameguna2TextBox.Text == "" || TAddressguna2TextBox.Text == "" || TPhoneguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"insert into TeacherTable values( '{TIDguna2TextBox.Text}','{TNameguna2TextBox.Text}', '{guna2ComboBox1.SelectedItem.ToString()}','{guna2DateTimePicker1.Text}','{TPhoneguna2TextBox.Text}', '{guna2ComboBox2.SelectedValue.ToString()}' , '{TAddressguna2TextBox.Text}')";
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


        private void guna2Button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (TIDguna2TextBox.Text == "" || TNameguna2TextBox.Text == "" || TAddressguna2TextBox.Text == "" || TPhoneguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update TeacherTable set TeacherName = ('{TNameguna2TextBox.Text}'), TeacherGender = ('{guna2ComboBox1.SelectedItem.ToString()} ') ,TeacherDOB = ('{guna2DateTimePicker1.Text}'), TeacherPhone =  (' {TPhoneguna2TextBox.Text} ') , TeacherDep = ('{guna2ComboBox2.SelectedValue.ToString()}') , TeacherAdd =('{TAddressguna2TextBox.Text}') where TeacherId = ('{TIDguna2TextBox.Text}')";
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

        private void Teacherguna2DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TIDguna2TextBox.Text = Teacherguna2DataGridView.SelectedRows[0].Cells[0].Value.ToString();
            TNameguna2TextBox.Text = Teacherguna2DataGridView.SelectedRows[0].Cells[1].Value.ToString();
            guna2ComboBox1.SelectedItem = Teacherguna2DataGridView.SelectedRows[0].Cells[2].Value.ToString();
            TPhoneguna2TextBox.Text = Teacherguna2DataGridView.SelectedRows[0].Cells[4].Value.ToString();
            TAddressguna2TextBox.Text = Teacherguna2DataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (TIDguna2TextBox.Text == "")
                {
                    MessageBox.Show("Enter The Teacher's Id");
                }
                else
                {
                    string query = $"delete from TeacherTable where TeacherId = ( '{TIDguna2TextBox.Text}')";
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

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
    }
}


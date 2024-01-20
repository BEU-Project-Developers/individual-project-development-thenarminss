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
            populate();
        }

        private void populate()
        {
            string query = "select * from DepartmentTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            Depguna2DataGridView.DataSource = dataTable;

        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DepNameguna2TextBox.Text == "" || DepDescriptionguna2TextBox.Text == "" || DepDurationguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"insert into DepartmentTable values( '{DepNameguna2TextBox.Text}','{DepDescriptionguna2TextBox.Text}', '{DepDurationguna2TextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Department Successfully Added");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DepNameguna2TextBox.Text == "" || DepDescriptionguna2TextBox.Text == "" || DepDurationguna2TextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update DepartmentTable set DepDesc = ('{DepDescriptionguna2TextBox.Text}'), DepDuration = ('{DepDurationguna2TextBox.Text}') where DepName = ('{DepNameguna2TextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Department Updated Successfully");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Department Not Updated");
            }
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DepNameguna2TextBox.Text == "")
                {
                    MessageBox.Show("Enter The Department Name");
                }
                else
                {

                    string query = $"delete from DepartmentTable where DepName = ( '{DepNameguna2TextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Department Deleted Successfuly");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Department Not Deleted");
            }
        }

        private void Depguna2DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameguna2TextBox.Text = Depguna2DataGridView.SelectedRows[0].Cells[0].Value.ToString();
            DepDescriptionguna2TextBox.Text = Depguna2DataGridView.SelectedRows[0].Cells[1].Value.ToString();
            DepDurationguna2TextBox.Text = Depguna2DataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
    }
}

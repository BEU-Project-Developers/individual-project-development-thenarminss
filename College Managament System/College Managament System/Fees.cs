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
using static System.Windows.Forms.AxHost;

namespace College_Managament_System
{
    public partial class Fees : Form
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public Fees()
        {
            InitializeComponent();
        }

        private void Fees_Load(object sender, EventArgs e)
        {
            fillDepartment();
            populate();
        }
        private void fillDepartment()
        {
            string query = "select StdId from StudentTable";
            var dataTable = dbContext.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                StdIdComboBox.ValueMember = "StdId";
                StdIdComboBox.DataSource = dataTable;
            }
            else
            {
                // Handle the case when there is no data in the StudentTable
                MessageBox.Show("No Students found.");
            }
        }

        private void StdIdComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string query = "select * from StudentTable where StdId = ('{StdIdComboBox.SelectedValue.ToString()}')";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                FeesNameTextBox.Text = dr["StdName"].ToString();
            }
        }

        private void populate()
        {
            string query = "select * from FeesTable";

            // Assuming dbContext is an instance of your DBContext class
            var dataTable = dbContext.ExecuteQuery(query);

            // Set the DataTable as the DataSource for your DataGridView
            FeesDGV.DataSource = dataTable;

        }
        private void Feespanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void updatestd()
        {
            string query = $"update StudentTable set StdFees = ('{FeesAmountTextBox.Text}') where StdId = ('{StdIdComboBox.SelectedValue.ToString()}')";
            dbContext.ExecuteNonQuery(query);
            //MessageBox.Show("User Updated Successfully");
            //populate();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }


        private void Label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FeesDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

//        private void Button1_Click(object sender, EventArgs e)
//{
//    try
//    {
//        if (FNumguna2TextBox.Text == "" || FNameguna2TextBox.Text == "" || FAmountguna2TextBox.Text == "")
//        {
//            MessageBox.Show("Missing Information");
//        }
//        else
//        {
//                    SqlDataAdapter da = new SqlDataAdapter("select count(*) from FeesTable where StdId = {guna2ComboBox1.SelectedValue.ToString()} and Period = '{guna2DateTimePicker1.Value.ToString("yyyy - MM - dd")}'"); ;
//            DataTable dt = new DataTable();
//            da.Fill(dt);
//            if (dt.Rows[0][0].ToString() == "1")
//            {
//                MessageBox.Show("No Dues For The Selected Period");
//            }
//            else
//            {
//                // Corrected SQL syntax and date formatting
//                string query = $"insert into FeesTable values ({FNumguna2TextBox.Text}, {guna2ComboBox1.SelectedValue.ToString()}, '{FNameguna2TextBox.Text}', '{guna2DateTimePicker1.Value.ToString("yyyy-MM-dd")}', {FAmountguna2TextBox.Text})";
//                SqlCommand cmd = new SqlCommand(query);
//                cmd.ExecuteNonQuery();
//                MessageBox.Show("Fees Successfully Added");
//                populate();
//                updatestd();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show($"An error occurred: {ex.Message}");
//    }
}

    }
//}
  
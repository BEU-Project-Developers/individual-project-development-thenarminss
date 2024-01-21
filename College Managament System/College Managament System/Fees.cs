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

            // Set StdNameTextBox to be read-only
            //StdNameTextBox.ReadOnly = true;
        }


        private void Fees_Load(object sender, EventArgs e)
        {
            fillStdId();
            populate();
        }
        private void fillStdId()
        {
            try
            {
                string query = "select StdId from StudentTable";
                DataTable dt = dbContext.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    StdIdComboBox.ValueMember = "StdId";
                    StdIdComboBox.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No students found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void StdIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchData();
        }
        string StdName;
            public void FetchData()// Method to fetch data for a selected Employee Id and update UI elements
            {
                
                string query = "select * from StudentTable where StdId = '" + StdIdComboBox.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    StdName = dr["StdName"].ToString();
                    
                    StdNameTextBox.Text = StdName;
                
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
            try
            {
                string query = $"update StudentTable set StdFees = '{FeesAmountTextBox.Text}' where StdId = '{StdIdComboBox.SelectedValue.ToString()}'";
                dbContext.ExecuteNonQuery(query);
                //populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
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
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }


        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Century Gothic", 25, FontStyle.Bold);
            e.Graphics.DrawString("Fees Receipt", font, Brushes.Red, new Point(230, 10));

            Font font1 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString("Receipt Number: ", font1, Brushes.Blue, new Point(40, 50));
            Font font6 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[0].Value.ToString(), font6, Brushes.Black, new Point(300, 50));


            Font font2 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString("Student Usn: ", font2, Brushes.Blue, new Point(40, 80));
            Font font7 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[1].Value.ToString(), font7, Brushes.Black, new Point(300, 80));



            Font font3 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString("Student Name: ", font3, Brushes.Blue, new Point(40, 110));
            Font font8 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[2].Value.ToString(), font8, Brushes.Black, new Point(300, 110));



            Font font4 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString("Period: ", font4, Brushes.Blue, new Point(40, 140));
            Font font9 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[3].Value.ToString(), font9, Brushes.Black, new Point(300, 140));



            Font font5 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString("Amount: ", font5, Brushes.Blue, new Point(40, 170));
            Font font10 = new Font("Century Gothic", 20, FontStyle.Bold);
            e.Graphics.DrawString("Rs" + FeesDGV.SelectedRows[0].Cells[4].Value.ToString(), font10, Brushes.Black, new Point(300, 170));

            Font font11 = new Font("Century Gothic", 18, FontStyle.Bold);
            e.Graphics.DrawString("Baku Engineering University", font11, Brushes.Red, new Point(230, 250));
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (FeesNumTextBox.Text == "" || StdNameTextBox.Text == "" || FeesAmountTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    string countQuery = $"select count(*) from FeesTable where StdId = {StdIdComboBox.SelectedValue.ToString()} and Period = '{FeesDateTimePicker.Value.ToString("yyyy-MM-dd")}'";
                    int rowCount = (int)dbContext.ExecuteNonQuery(countQuery);

                    if (rowCount == 1)
                    {
                        MessageBox.Show("No Dues For The Selected Period");
                    }
                    else
                    {
                        string insertQuery = $"insert into FeesTable values ({FeesNumTextBox.Text}, {StdIdComboBox.SelectedValue.ToString()}, '{StdNameTextBox.Text}', '{FeesDateTimePicker.Value.ToString("yyyy-MM-dd")}', {FeesAmountTextBox.Text})";
                        dbContext.ExecuteNonQuery(insertQuery);

                        MessageBox.Show("Fees Successfully Payed");
                        populate();
                        updatestd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (FeesNumTextBox.Text == "" || StdNameTextBox.Text == "" || FeesAmountTextBox.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string query = $"update FeesTable set StdId = '{StdIdComboBox.Text}', StdName = '{StdNameTextBox.Text}', Period = '{FeesDateTimePicker.Text}', Amount = '{FeesAmountTextBox.Text}',' where FeesNum = '{FeesNumTextBox.Text}'";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Fees Updated Successfully");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Fees Not Updated");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FeesNumTextBox.Text == "")
                {
                    MessageBox.Show("Enter The Fee's Num");
                }
                else
                {
                    string query = $"delete from StudentTable where FeesNum = ( '{FeesNumTextBox.Text}')";
                    dbContext.ExecuteNonQuery(query);
                    MessageBox.Show("Fees Deleted Successfuly");
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("Ooops... Fees Not Deleted");
            }
        }
    }
}

  
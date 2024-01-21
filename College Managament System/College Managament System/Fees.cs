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
            StdNameTextBox.ReadOnly = true;
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
            try
            {
                if (StdIdComboBox.SelectedValue != null)
                {
                    string selectedStdId = StdIdComboBox.SelectedValue.ToString();
                    string query = $"select StdName from StudentTable where StdId = '{selectedStdId}'";
                    DataTable dt = dbContext.ExecuteQuery(query);

                    if (dt.Rows.Count > 0)
                    {
                        StdNameTextBox.Text = dt.Rows[0]["StdName"]?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("No student found with the selected ID.");
                    }
                }
                else
                {
                    MessageBox.Show("SelectedValue is null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
        private void Button1_Click(object sender, EventArgs e)
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

                        MessageBox.Show("Fees Successfully Added");
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Specify a valid font family, for example, "Century Gothic"
            Font font = new Font("Century Gothic", 25, FontStyle.Bold);

            // Use Brushes.Blue instead of Brushes.DarkBlue
            e.Graphics.DrawString("Fees Receipt", font, Brushes.Blue, new Point(230, 10));
        }

    }
}

  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Managament_System
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            // Any initialization logic for the Mainform can be placed here
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            // Open the Student form and hide the current Mainform
            Student std = new Student();
            std.Show();
            this.Hide();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            // Open the Teacher form and hide the current Mainform
            Teacher teacher = new Teacher();
            teacher.Show();
            this.Hide();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            // Open the UserForm and hide the current Mainform
            UserForm user = new UserForm();
            user.Show();
            this.Hide();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            // Open the Fees form and hide the current Mainform
            Fees payment = new Fees();
            payment.Show();
            this.Hide();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            // Open the Department form and hide the current Mainform
            Department dep = new Department();
            dep.Show();
            this.Hide();
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            // Exit the application when Button6 is clicked
            Application.Exit();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            // Exit the application when Label2 is clicked
            Application.Exit();
        }
    }
}


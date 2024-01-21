using System;
using System.Windows.Forms;

namespace College_Managament_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Variable to track the progress
        int startpos = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the timer when the form loads
            timer1.Start();
        }

        private void MyprogressBar_Click_1(object sender, EventArgs e)
        {
            // Click event for the progress bar (empty in this case)
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Timer tick event, executed on each tick
            startpos += 1;

            // Set the ProgressBar value to the current progress
            Myprogressbar.Value = startpos;

            if (Myprogressbar.Value == 100)
            {
                // When progress reaches 100%, stop the timer, open the login form, and hide the current form
                Myprogressbar.Value = 0;
                timer1.Stop();
                login log = new login();
                log.Show();
                this.Hide();
            }
        }
    }
}

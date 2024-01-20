namespace College_Managament_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int startpos = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void MyprogressBar_Click_1(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            Myprogressbar.Value = startpos;
            if (Myprogressbar.Value == 100)
            {
                Myprogressbar.Value = 0;
                timer1.Stop();
                login log = new login();
                log.Show();
                this.Hide();
            }
        }
    }
}
namespace College_Managament_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Myprogressbar = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            Label1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Label2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // Myprogressbar
            // 
            Myprogressbar.ForeColor = Color.White;
            Myprogressbar.Location = new Point(12, 332);
            Myprogressbar.Name = "Myprogressbar";
            Myprogressbar.Size = new Size(576, 16);
            Myprogressbar.TabIndex = 2;
            Myprogressbar.Click += MyprogressBar_Click_1;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Label1
            // 
            Label1.BackColor = Color.Transparent;
            Label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            Label1.ForeColor = Color.White;
            Label1.Location = new Point(135, 125);
            Label1.Name = "Label1";
            Label1.Size = new Size(332, 39);
            Label1.TabIndex = 9;
            Label1.Text = "BEU Management System";
            Label1.Click += guna2HtmlLabel1_Click_1;
            // 
            // Label2
            // 
            Label2.BackColor = Color.Transparent;
            Label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Label2.ForeColor = Color.White;
            Label2.Location = new Point(380, 170);
            Label2.Name = "Label2";
            Label2.Size = new Size(87, 25);
            Label2.TabIndex = 10;
            Label2.Text = "Version 1.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(600, 360);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(Myprogressbar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar Myprogressbar;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Label2;
    }
}
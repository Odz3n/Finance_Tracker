namespace Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            login_signupBtn = new Button();
            label6 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            close = new Label();
            label3 = new Label();
            label4 = new Label();
            login_username = new TextBox();
            login_password = new TextBox();
            label5 = new Label();
            login_btn = new Button();
            login_showPass = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 25, 50);
            panel1.Controls.Add(login_signupBtn);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(960, 1080);
            panel1.TabIndex = 0;
            // 
            // login_signupBtn
            // 
            login_signupBtn.BackColor = Color.FromArgb(0, 25, 50);
            login_signupBtn.FlatAppearance.BorderSize = 2;
            login_signupBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 25, 25);
            login_signupBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            login_signupBtn.FlatStyle = FlatStyle.Flat;
            login_signupBtn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_signupBtn.ForeColor = Color.White;
            login_signupBtn.Location = new Point(38, 959);
            login_signupBtn.Name = "login_signupBtn";
            login_signupBtn.Size = new Size(884, 85);
            login_signupBtn.TabIndex = 8;
            login_signupBtn.Text = "SIGN UP";
            login_signupBtn.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(315, 890);
            label6.Name = "label6";
            label6.Size = new Size(335, 52);
            label6.TabIndex = 2;
            label6.Text = "REGISTER HERE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(242, 700);
            label2.Name = "label2";
            label2.Size = new Size(486, 58);
            label2.TabIndex = 1;
            label2.Text = "FINANCE TRACKER";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(163, 269);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(623, 381);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // close
            // 
            close.AutoSize = true;
            close.Font = new Font("Arial", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            close.Location = new Point(1874, 9);
            close.Name = "close";
            close.Size = new Size(34, 34);
            close.TabIndex = 0;
            close.Text = "X";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(1001, 191);
            label3.Name = "label3";
            label3.Size = new Size(178, 52);
            label3.TabIndex = 2;
            label3.Text = "SIGN IN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(1001, 361);
            label4.Name = "label4";
            label4.Size = new Size(183, 45);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // login_username
            // 
            login_username.BorderStyle = BorderStyle.FixedSingle;
            login_username.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_username.Location = new Point(1013, 428);
            login_username.Name = "login_username";
            login_username.Size = new Size(858, 57);
            login_username.TabIndex = 4;
            login_username.TextChanged += textBox1_TextChanged;
            // 
            // login_password
            // 
            login_password.BorderStyle = BorderStyle.FixedSingle;
            login_password.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_password.Location = new Point(1013, 587);
            login_password.Name = "login_password";
            login_password.Size = new Size(858, 57);
            login_password.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(1001, 520);
            label5.Name = "label5";
            label5.Size = new Size(173, 45);
            label5.TabIndex = 5;
            label5.Text = "Password";
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(0, 25, 50);
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 25, 25);
            login_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(1013, 765);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(217, 85);
            login_btn.TabIndex = 7;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            // 
            // login_showPass
            // 
            login_showPass.AutoSize = true;
            login_showPass.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 25, 50);
            login_showPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_showPass.Location = new Point(1600, 659);
            login_showPass.Name = "login_showPass";
            login_showPass.Size = new Size(271, 49);
            login_showPass.TabIndex = 8;
            login_showPass.Text = "Show Password";
            login_showPass.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1920, 1080);
            Controls.Add(login_showPass);
            Controls.Add(login_btn);
            Controls.Add(login_password);
            Controls.Add(label5);
            Controls.Add(login_username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(close);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label close;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox login_username;
        private TextBox login_password;
        private Label label5;
        private Button login_btn;
        private CheckBox login_showPass;
        private Button login_signupBtn;
        private Label label6;
    }
}

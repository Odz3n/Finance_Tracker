namespace Client
{
    partial class LoginUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUI));
            panel1 = new Panel();
            login_signupBtn = new Button();
            login_registerLbl = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            login_signinLbl = new Label();
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
            panel1.Controls.Add(login_registerLbl);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(960, 1009);
            panel1.TabIndex = 0;
            // 
            // login_signupBtn
            // 
            login_signupBtn.BackColor = Color.FromArgb(0, 25, 50);
            login_signupBtn.Cursor = Cursors.Hand;
            login_signupBtn.FlatAppearance.BorderSize = 2;
            login_signupBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            login_signupBtn.FlatAppearance.MouseOverBackColor = Color.Blue;
            login_signupBtn.FlatStyle = FlatStyle.Flat;
            login_signupBtn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_signupBtn.ForeColor = Color.White;
            login_signupBtn.Location = new Point(38, 907);
            login_signupBtn.Name = "login_signupBtn";
            login_signupBtn.Size = new Size(884, 85);
            login_signupBtn.TabIndex = 8;
            login_signupBtn.Text = "SIGN UP";
            login_signupBtn.UseVisualStyleBackColor = false;
            login_signupBtn.Click += login_signupBtn_Click;
            // 
            // login_registerLbl
            // 
            login_registerLbl.AutoSize = true;
            login_registerLbl.Font = new Font("Tahoma", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_registerLbl.ForeColor = Color.White;
            login_registerLbl.Location = new Point(315, 838);
            login_registerLbl.Name = "login_registerLbl";
            login_registerLbl.Size = new Size(335, 52);
            login_registerLbl.TabIndex = 2;
            login_registerLbl.Text = "REGISTER HERE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(242, 648);
            label2.Name = "label2";
            label2.Size = new Size(486, 58);
            label2.TabIndex = 1;
            label2.Text = "FINANCE TRACKER";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(163, 217);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(623, 381);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // login_signinLbl
            // 
            login_signinLbl.AutoSize = true;
            login_signinLbl.Font = new Font("Tahoma", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_signinLbl.Location = new Point(1001, 191);
            login_signinLbl.Name = "login_signinLbl";
            login_signinLbl.Size = new Size(178, 52);
            login_signinLbl.TabIndex = 2;
            login_signinLbl.Text = "SIGN IN";
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
            login_username.Cursor = Cursors.IBeam;
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
            login_password.Cursor = Cursors.IBeam;
            login_password.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_password.Location = new Point(1013, 587);
            login_password.Name = "login_password";
            login_password.Size = new Size(858, 57);
            login_password.TabIndex = 6;
            login_password.UseSystemPasswordChar = true;
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
            login_btn.Cursor = Cursors.Hand;
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            login_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(1013, 765);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(217, 85);
            login_btn.TabIndex = 7;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
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
            login_showPass.CheckedChanged += login_showPass_CheckedChanged;
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1894, 1009);
            Controls.Add(login_showPass);
            Controls.Add(login_btn);
            Controls.Add(login_password);
            Controls.Add(label5);
            Controls.Add(login_username);
            Controls.Add(label4);
            Controls.Add(login_signinLbl);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Finance Tracker";
            Load += LoginUI_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label login_signinLbl;
        private Label label4;
        private TextBox login_username;
        private TextBox login_password;
        private Label label5;
        private Button login_btn;
        private CheckBox login_showPass;
        private Button login_signupBtn;
        private Label login_registerLbl;
    }
}

namespace Client
{
    partial class ClientUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientUI));
            ClientUserPanel_pnl = new Panel();
            ClientLogout_btn = new Button();
            ClientTransaction_btn = new Button();
            ClientCategory_btn = new Button();
            ClientWallet_btn = new Button();
            ClientDashboard_btn = new Button();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ClientPanel_pnl = new Panel();
            ClientUserPanel_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ClientUserPanel_pnl
            // 
            ClientUserPanel_pnl.BackColor = Color.FromArgb(0, 25, 50);
            ClientUserPanel_pnl.Controls.Add(ClientLogout_btn);
            ClientUserPanel_pnl.Controls.Add(ClientTransaction_btn);
            ClientUserPanel_pnl.Controls.Add(ClientCategory_btn);
            ClientUserPanel_pnl.Controls.Add(ClientWallet_btn);
            ClientUserPanel_pnl.Controls.Add(ClientDashboard_btn);
            ClientUserPanel_pnl.Controls.Add(label2);
            ClientUserPanel_pnl.Controls.Add(label1);
            ClientUserPanel_pnl.Controls.Add(pictureBox1);
            ClientUserPanel_pnl.Dock = DockStyle.Left;
            ClientUserPanel_pnl.Location = new Point(0, 0);
            ClientUserPanel_pnl.Name = "ClientUserPanel_pnl";
            ClientUserPanel_pnl.Size = new Size(400, 1009);
            ClientUserPanel_pnl.TabIndex = 0;
            ClientUserPanel_pnl.Paint += ClientUserPanel_pnl_Paint;
            // 
            // ClientLogout_btn
            // 
            ClientLogout_btn.BackColor = Color.FromArgb(0, 25, 50);
            ClientLogout_btn.Dock = DockStyle.Bottom;
            ClientLogout_btn.FlatAppearance.BorderSize = 0;
            ClientLogout_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            ClientLogout_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ClientLogout_btn.FlatStyle = FlatStyle.Flat;
            ClientLogout_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientLogout_btn.ForeColor = Color.White;
            ClientLogout_btn.Image = (Image)resources.GetObject("ClientLogout_btn.Image");
            ClientLogout_btn.ImageAlign = ContentAlignment.MiddleLeft;
            ClientLogout_btn.Location = new Point(0, 931);
            ClientLogout_btn.Name = "ClientLogout_btn";
            ClientLogout_btn.Padding = new Padding(15);
            ClientLogout_btn.Size = new Size(400, 78);
            ClientLogout_btn.TabIndex = 8;
            ClientLogout_btn.Text = "Logout";
            ClientLogout_btn.UseVisualStyleBackColor = false;
            ClientLogout_btn.Click += ClientLogout_btn_Click;
            // 
            // ClientTransaction_btn
            // 
            ClientTransaction_btn.BackColor = Color.FromArgb(0, 25, 50);
            ClientTransaction_btn.FlatAppearance.BorderSize = 0;
            ClientTransaction_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            ClientTransaction_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ClientTransaction_btn.FlatStyle = FlatStyle.Flat;
            ClientTransaction_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientTransaction_btn.ForeColor = Color.White;
            ClientTransaction_btn.Image = (Image)resources.GetObject("ClientTransaction_btn.Image");
            ClientTransaction_btn.ImageAlign = ContentAlignment.MiddleLeft;
            ClientTransaction_btn.Location = new Point(12, 690);
            ClientTransaction_btn.Name = "ClientTransaction_btn";
            ClientTransaction_btn.Size = new Size(367, 78);
            ClientTransaction_btn.TabIndex = 7;
            ClientTransaction_btn.Text = "      Add Transactions";
            ClientTransaction_btn.UseVisualStyleBackColor = false;
            ClientTransaction_btn.Click += ClientTransaction_btn_Click;
            // 
            // ClientCategory_btn
            // 
            ClientCategory_btn.BackColor = Color.FromArgb(0, 25, 50);
            ClientCategory_btn.FlatAppearance.BorderSize = 0;
            ClientCategory_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            ClientCategory_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ClientCategory_btn.FlatStyle = FlatStyle.Flat;
            ClientCategory_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientCategory_btn.ForeColor = Color.White;
            ClientCategory_btn.Image = (Image)resources.GetObject("ClientCategory_btn.Image");
            ClientCategory_btn.ImageAlign = ContentAlignment.MiddleLeft;
            ClientCategory_btn.Location = new Point(12, 574);
            ClientCategory_btn.Name = "ClientCategory_btn";
            ClientCategory_btn.Size = new Size(367, 78);
            ClientCategory_btn.TabIndex = 5;
            ClientCategory_btn.Text = "Add Category";
            ClientCategory_btn.UseVisualStyleBackColor = false;
            ClientCategory_btn.Click += ClientCategory_btn_Click;
            // 
            // ClientWallet_btn
            // 
            ClientWallet_btn.BackColor = Color.FromArgb(0, 25, 50);
            ClientWallet_btn.FlatAppearance.BorderSize = 0;
            ClientWallet_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            ClientWallet_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ClientWallet_btn.FlatStyle = FlatStyle.Flat;
            ClientWallet_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientWallet_btn.ForeColor = Color.White;
            ClientWallet_btn.Image = (Image)resources.GetObject("ClientWallet_btn.Image");
            ClientWallet_btn.ImageAlign = ContentAlignment.MiddleLeft;
            ClientWallet_btn.Location = new Point(12, 459);
            ClientWallet_btn.Name = "ClientWallet_btn";
            ClientWallet_btn.Size = new Size(367, 78);
            ClientWallet_btn.TabIndex = 4;
            ClientWallet_btn.Text = "Wallet";
            ClientWallet_btn.UseVisualStyleBackColor = false;
            ClientWallet_btn.Click += ClientWallet_btn_Click;
            // 
            // ClientDashboard_btn
            // 
            ClientDashboard_btn.BackColor = Color.FromArgb(0, 25, 50);
            ClientDashboard_btn.FlatAppearance.BorderSize = 0;
            ClientDashboard_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            ClientDashboard_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ClientDashboard_btn.FlatStyle = FlatStyle.Flat;
            ClientDashboard_btn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientDashboard_btn.ForeColor = Color.White;
            ClientDashboard_btn.Image = (Image)resources.GetObject("ClientDashboard_btn.Image");
            ClientDashboard_btn.ImageAlign = ContentAlignment.MiddleLeft;
            ClientDashboard_btn.Location = new Point(12, 351);
            ClientDashboard_btn.Name = "ClientDashboard_btn";
            ClientDashboard_btn.Size = new Size(367, 78);
            ClientDashboard_btn.TabIndex = 3;
            ClientDashboard_btn.Text = "Dashboard";
            ClientDashboard_btn.UseVisualStyleBackColor = false;
            ClientDashboard_btn.Click += ClientDashboard_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.125F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(202, 284);
            label2.Name = "label2";
            label2.Size = new Size(90, 33);
            label2.TabIndex = 2;
            label2.Text = "Admin";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.125F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(76, 284);
            label1.Name = "label1";
            label1.Size = new Size(131, 33);
            label1.TabIndex = 1;
            label1.Text = "Welcome,";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ClientPanel_pnl
            // 
            ClientPanel_pnl.Dock = DockStyle.Fill;
            ClientPanel_pnl.Location = new Point(400, 0);
            ClientPanel_pnl.Name = "ClientPanel_pnl";
            ClientPanel_pnl.Size = new Size(1494, 1009);
            ClientPanel_pnl.TabIndex = 1;
            ClientPanel_pnl.Paint += ClientPanel_pnl_Paint;
            // 
            // ClientUI
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            ClientSize = new Size(1894, 1009);
            Controls.Add(ClientPanel_pnl);
            Controls.Add(ClientUserPanel_pnl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "ClientUI";
            Text = "Finance Tracker";
            Load += ClientUI_Load;
            ClientUserPanel_pnl.ResumeLayout(false);
            ClientUserPanel_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ClientUserPanel_pnl;
        private PictureBox pictureBox1;
        private Label label1;
        private Button ClientDashboard_btn;
        private Label label2;
        private Button ClientCategory_btn;
        private Button ClientWallet_btn;
        private Button ClientTransaction_btn;
        private Button ClientLogout_btn;
        private Panel ClientPanel_pnl;
    }
}
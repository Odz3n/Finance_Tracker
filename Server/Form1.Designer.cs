namespace Server
{
    partial class Form_Login
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
            tbIp = new TextBox();
            lbActiveUsers = new ListBox();
            tbPort = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnDisconnect = new Button();
            lbLogs = new ListBox();
            SuspendLayout();
            // 
            // tbIp
            // 
            tbIp.Location = new Point(168, 12);
            tbIp.Name = "tbIp";
            tbIp.PlaceholderText = "IP";
            tbIp.Size = new Size(100, 23);
            tbIp.TabIndex = 0;
            tbIp.Text = "127.0.0.1";
            // 
            // lbActiveUsers
            // 
            lbActiveUsers.FormattingEnabled = true;
            lbActiveUsers.Location = new Point(12, 12);
            lbActiveUsers.Name = "lbActiveUsers";
            lbActiveUsers.ScrollAlwaysVisible = true;
            lbActiveUsers.Size = new Size(150, 139);
            lbActiveUsers.TabIndex = 1;
            // 
            // tbPort
            // 
            tbPort.Location = new Point(168, 41);
            tbPort.Name = "tbPort";
            tbPort.PlaceholderText = "Port";
            tbPort.Size = new Size(100, 23);
            tbPort.TabIndex = 2;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(193, 70);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(193, 99);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(193, 128);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // lbLogs
            // 
            lbLogs.FormattingEnabled = true;
            lbLogs.Location = new Point(12, 157);
            lbLogs.Name = "lbLogs";
            lbLogs.Size = new Size(254, 109);
            lbLogs.TabIndex = 6;
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 278);
            Controls.Add(lbLogs);
            Controls.Add(btnDisconnect);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(tbPort);
            Controls.Add(lbActiveUsers);
            Controls.Add(tbIp);
            Name = "Form_Login";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbIp;
        private ListBox lbActiveUsers;
        private TextBox tbPort;
        private Button btnStart;
        private Button btnStop;
        private Button btnDisconnect;
        private ListBox lbLogs;
    }
}

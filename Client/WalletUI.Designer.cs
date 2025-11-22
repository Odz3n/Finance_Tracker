namespace Client
{
    partial class WalletUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            WalletNameBX = new TextBox();
            WalletCurrencyBX = new ComboBox();
            WalletDel_btn = new Button();
            WalletUpdate_btn = new Button();
            WalletAdd_btn = new Button();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            WalletDataList = new DataGridView();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WalletDataList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(WalletNameBX);
            panel1.Controls.Add(WalletCurrencyBX);
            panel1.Controls.Add(WalletDel_btn);
            panel1.Controls.Add(WalletUpdate_btn);
            panel1.Controls.Add(WalletAdd_btn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(16, 14);
            panel1.Margin = new Padding(2, 1, 2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(215, 445);
            panel1.TabIndex = 0;
            // 
            // WalletNameBX
            // 
            WalletNameBX.BorderStyle = BorderStyle.FixedSingle;
            WalletNameBX.Location = new Point(11, 45);
            WalletNameBX.Margin = new Padding(2, 1, 2, 1);
            WalletNameBX.Name = "WalletNameBX";
            WalletNameBX.Size = new Size(192, 23);
            WalletNameBX.TabIndex = 13;
            // 
            // WalletCurrencyBX
            // 
            WalletCurrencyBX.FormattingEnabled = true;
            WalletCurrencyBX.Location = new Point(11, 110);
            WalletCurrencyBX.Margin = new Padding(2, 1, 2, 1);
            WalletCurrencyBX.Name = "WalletCurrencyBX";
            WalletCurrencyBX.Size = new Size(192, 23);
            WalletCurrencyBX.TabIndex = 12;
            // 
            // WalletDel_btn
            // 
            WalletDel_btn.BackColor = Color.FromArgb(0, 25, 50);
            WalletDel_btn.Cursor = Cursors.Hand;
            WalletDel_btn.FlatAppearance.BorderSize = 0;
            WalletDel_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            WalletDel_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            WalletDel_btn.FlatStyle = FlatStyle.Flat;
            WalletDel_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            WalletDel_btn.ForeColor = Color.White;
            WalletDel_btn.Location = new Point(110, 154);
            WalletDel_btn.Margin = new Padding(2, 1, 2, 1);
            WalletDel_btn.Name = "WalletDel_btn";
            WalletDel_btn.Size = new Size(92, 28);
            WalletDel_btn.TabIndex = 10;
            WalletDel_btn.Text = "Delete";
            WalletDel_btn.UseVisualStyleBackColor = false;
            WalletDel_btn.Click += WalletDel_btn_Click;
            // 
            // WalletUpdate_btn
            // 
            WalletUpdate_btn.BackColor = Color.FromArgb(0, 25, 50);
            WalletUpdate_btn.Cursor = Cursors.Hand;
            WalletUpdate_btn.FlatAppearance.BorderSize = 0;
            WalletUpdate_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            WalletUpdate_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            WalletUpdate_btn.FlatStyle = FlatStyle.Flat;
            WalletUpdate_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            WalletUpdate_btn.ForeColor = Color.White;
            WalletUpdate_btn.Location = new Point(11, 198);
            WalletUpdate_btn.Margin = new Padding(2, 1, 2, 1);
            WalletUpdate_btn.Name = "WalletUpdate_btn";
            WalletUpdate_btn.Size = new Size(191, 28);
            WalletUpdate_btn.TabIndex = 9;
            WalletUpdate_btn.Text = "Update";
            WalletUpdate_btn.UseVisualStyleBackColor = false;
            WalletUpdate_btn.Click += WalletUpdate_btn_Click;
            // 
            // WalletAdd_btn
            // 
            WalletAdd_btn.BackColor = Color.FromArgb(0, 25, 50);
            WalletAdd_btn.Cursor = Cursors.Hand;
            WalletAdd_btn.FlatAppearance.BorderSize = 0;
            WalletAdd_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            WalletAdd_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            WalletAdd_btn.FlatStyle = FlatStyle.Flat;
            WalletAdd_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            WalletAdd_btn.ForeColor = Color.White;
            WalletAdd_btn.Location = new Point(11, 154);
            WalletAdd_btn.Margin = new Padding(2, 1, 2, 1);
            WalletAdd_btn.Name = "WalletAdd_btn";
            WalletAdd_btn.Size = new Size(92, 28);
            WalletAdd_btn.TabIndex = 8;
            WalletAdd_btn.Text = "Add";
            WalletAdd_btn.UseVisualStyleBackColor = false;
            WalletAdd_btn.Click += WalletAdd_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(15, 81);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(85, 23);
            label2.TabIndex = 4;
            label2.Text = "Currency";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 2;
            label1.Text = "Wallet";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(WalletDataList);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(250, 14);
            panel2.Margin = new Padding(2, 1, 2, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(538, 445);
            panel2.TabIndex = 1;
            // 
            // WalletDataList
            // 
            WalletDataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 25, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            WalletDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            WalletDataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WalletDataList.Location = new Point(16, 45);
            WalletDataList.Margin = new Padding(2, 1, 2, 1);
            WalletDataList.Name = "WalletDataList";
            WalletDataList.RowHeadersWidth = 82;
            WalletDataList.Size = new Size(509, 384);
            WalletDataList.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(16, 15);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 3;
            label3.Text = "Wallet List";
            // 
            // WalletUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "WalletUI";
            Size = new Size(804, 473);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WalletDataList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Button WalletUpdate_btn;
        private Button WalletAdd_btn;
        private Label label3;
        private Button WalletDel_btn;
        private ComboBox WalletCurrencyBX;
        private DataGridView WalletDataList;
        private TextBox WalletNameBX;
    }
}

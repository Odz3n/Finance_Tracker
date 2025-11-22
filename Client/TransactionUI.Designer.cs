namespace Client
{
    partial class TransactionUI
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
            panel2 = new Panel();
            TransactionList = new DataGridView();
            label3 = new Label();
            panel1 = new Panel();
            TransactionAddAmount_BX = new TextBox();
            TransactionFilterCategory_BX = new ComboBox();
            label12 = new Label();
            TransactionFilterWallet_BX = new ComboBox();
            label11 = new Label();
            TransactionFilterType_BX = new ComboBox();
            label10 = new Label();
            TransactionDel_BX = new ComboBox();
            label9 = new Label();
            label4 = new Label();
            TransactionAddDateTime = new DateTimePicker();
            TransactionAddDetails_BX = new TextBox();
            label8 = new Label();
            label7 = new Label();
            TransactionFilterEndDate_BX = new DateTimePicker();
            label6 = new Label();
            TransactionAddCategory_BX = new ComboBox();
            label5 = new Label();
            TransactionFilterStartDate_BX = new DateTimePicker();
            TransactionAddCurrency_Bx = new ComboBox();
            TransactionAddWallet_BX = new ComboBox();
            TransactionDel_btn = new Button();
            TransactionFilter_btn = new Button();
            TransactionAdd_btn = new Button();
            label2 = new Label();
            label1 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TransactionList).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(TransactionList);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(16, 14);
            panel2.Margin = new Padding(2, 1, 2, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(771, 230);
            panel2.TabIndex = 4;
            // 
            // TransactionList
            // 
            TransactionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 25, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            TransactionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            TransactionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransactionList.Location = new Point(16, 48);
            TransactionList.Margin = new Padding(2, 1, 2, 1);
            TransactionList.Name = "TransactionList";
            TransactionList.RowHeadersWidth = 82;
            TransactionList.Size = new Size(740, 169);
            TransactionList.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(16, 15);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(140, 23);
            label3.TabIndex = 3;
            label3.Text = "Transaction List";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(TransactionAddAmount_BX);
            panel1.Controls.Add(TransactionFilterCategory_BX);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(TransactionFilterWallet_BX);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(TransactionFilterType_BX);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(TransactionDel_BX);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TransactionAddDateTime);
            panel1.Controls.Add(TransactionAddDetails_BX);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(TransactionFilterEndDate_BX);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TransactionAddCategory_BX);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TransactionFilterStartDate_BX);
            panel1.Controls.Add(TransactionAddCurrency_Bx);
            panel1.Controls.Add(TransactionAddWallet_BX);
            panel1.Controls.Add(TransactionDel_btn);
            panel1.Controls.Add(TransactionFilter_btn);
            panel1.Controls.Add(TransactionAdd_btn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(16, 256);
            panel1.Margin = new Padding(2, 1, 2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(771, 199);
            panel1.TabIndex = 5;
            // 
            // TransactionAddAmount_BX
            // 
            TransactionAddAmount_BX.BorderStyle = BorderStyle.FixedSingle;
            TransactionAddAmount_BX.Location = new Point(114, 90);
            TransactionAddAmount_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionAddAmount_BX.Name = "TransactionAddAmount_BX";
            TransactionAddAmount_BX.Size = new Size(188, 23);
            TransactionAddAmount_BX.TabIndex = 41;
            // 
            // TransactionFilterCategory_BX
            // 
            TransactionFilterCategory_BX.FormattingEnabled = true;
            TransactionFilterCategory_BX.Location = new Point(613, 63);
            TransactionFilterCategory_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionFilterCategory_BX.Name = "TransactionFilterCategory_BX";
            TransactionFilterCategory_BX.Size = new Size(140, 23);
            TransactionFilterCategory_BX.TabIndex = 40;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tahoma", 10.875F);
            label12.Location = new Point(538, 63);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(67, 18);
            label12.TabIndex = 39;
            label12.Text = "Category";
            // 
            // TransactionFilterWallet_BX
            // 
            TransactionFilterWallet_BX.FormattingEnabled = true;
            TransactionFilterWallet_BX.Location = new Point(613, 11);
            TransactionFilterWallet_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionFilterWallet_BX.Name = "TransactionFilterWallet_BX";
            TransactionFilterWallet_BX.Size = new Size(140, 23);
            TransactionFilterWallet_BX.TabIndex = 38;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 10.875F);
            label11.Location = new Point(538, 11);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(47, 18);
            label11.TabIndex = 37;
            label11.Text = "Wallet";
            // 
            // TransactionFilterType_BX
            // 
            TransactionFilterType_BX.FormattingEnabled = true;
            TransactionFilterType_BX.Location = new Point(613, 37);
            TransactionFilterType_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionFilterType_BX.Name = "TransactionFilterType_BX";
            TransactionFilterType_BX.Size = new Size(140, 23);
            TransactionFilterType_BX.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 10.875F);
            label10.Location = new Point(538, 37);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(42, 18);
            label10.TabIndex = 35;
            label10.Text = "Type";
            // 
            // TransactionDel_BX
            // 
            TransactionDel_BX.FormattingEnabled = true;
            TransactionDel_BX.Location = new Point(318, 120);
            TransactionDel_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionDel_BX.Name = "TransactionDel_BX";
            TransactionDel_BX.Size = new Size(201, 23);
            TransactionDel_BX.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 10.875F);
            label9.Location = new Point(318, 97);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(189, 18);
            label9.TabIndex = 33;
            label9.Text = "Select Transaction to delete";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 10.875F);
            label4.Location = new Point(21, 120);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 18);
            label4.TabIndex = 32;
            label4.Text = "Timestamp";
            // 
            // TransactionAddDateTime
            // 
            TransactionAddDateTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            TransactionAddDateTime.Format = DateTimePickerFormat.Custom;
            TransactionAddDateTime.Location = new Point(114, 120);
            TransactionAddDateTime.Margin = new Padding(2, 1, 2, 1);
            TransactionAddDateTime.Name = "TransactionAddDateTime";
            TransactionAddDateTime.Size = new Size(189, 23);
            TransactionAddDateTime.TabIndex = 31;
            // 
            // TransactionAddDetails_BX
            // 
            TransactionAddDetails_BX.Location = new Point(318, 13);
            TransactionAddDetails_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionAddDetails_BX.Multiline = true;
            TransactionAddDetails_BX.Name = "TransactionAddDetails_BX";
            TransactionAddDetails_BX.PlaceholderText = "Write transaction details here.";
            TransactionAddDetails_BX.ScrollBars = ScrollBars.Vertical;
            TransactionAddDetails_BX.Size = new Size(201, 78);
            TransactionAddDetails_BX.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 10.875F);
            label8.Location = new Point(47, 92);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(59, 18);
            label8.TabIndex = 28;
            label8.Text = "Amount";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 10.875F);
            label7.Location = new Point(536, 120);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 18);
            label7.TabIndex = 27;
            label7.Text = "End date";
            // 
            // TransactionFilterEndDate_BX
            // 
            TransactionFilterEndDate_BX.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            TransactionFilterEndDate_BX.Format = DateTimePickerFormat.Custom;
            TransactionFilterEndDate_BX.Location = new Point(613, 120);
            TransactionFilterEndDate_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionFilterEndDate_BX.Name = "TransactionFilterEndDate_BX";
            TransactionFilterEndDate_BX.Size = new Size(140, 23);
            TransactionFilterEndDate_BX.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 10.875F);
            label6.Location = new Point(536, 90);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(73, 18);
            label6.TabIndex = 25;
            label6.Text = "Start date";
            // 
            // TransactionAddCategory_BX
            // 
            TransactionAddCategory_BX.FormattingEnabled = true;
            TransactionAddCategory_BX.Location = new Point(114, 65);
            TransactionAddCategory_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionAddCategory_BX.Name = "TransactionAddCategory_BX";
            TransactionAddCategory_BX.Size = new Size(189, 23);
            TransactionAddCategory_BX.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 10.875F);
            label5.Location = new Point(39, 65);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 18);
            label5.TabIndex = 21;
            label5.Text = "Category";
            // 
            // TransactionFilterStartDate_BX
            // 
            TransactionFilterStartDate_BX.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            TransactionFilterStartDate_BX.Format = DateTimePickerFormat.Custom;
            TransactionFilterStartDate_BX.Location = new Point(613, 90);
            TransactionFilterStartDate_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionFilterStartDate_BX.Name = "TransactionFilterStartDate_BX";
            TransactionFilterStartDate_BX.Size = new Size(140, 23);
            TransactionFilterStartDate_BX.TabIndex = 20;
            // 
            // TransactionAddCurrency_Bx
            // 
            TransactionAddCurrency_Bx.FormattingEnabled = true;
            TransactionAddCurrency_Bx.Location = new Point(114, 39);
            TransactionAddCurrency_Bx.Margin = new Padding(2, 1, 2, 1);
            TransactionAddCurrency_Bx.Name = "TransactionAddCurrency_Bx";
            TransactionAddCurrency_Bx.Size = new Size(189, 23);
            TransactionAddCurrency_Bx.TabIndex = 19;
            // 
            // TransactionAddWallet_BX
            // 
            TransactionAddWallet_BX.FormattingEnabled = true;
            TransactionAddWallet_BX.Location = new Point(114, 13);
            TransactionAddWallet_BX.Margin = new Padding(2, 1, 2, 1);
            TransactionAddWallet_BX.Name = "TransactionAddWallet_BX";
            TransactionAddWallet_BX.Size = new Size(189, 23);
            TransactionAddWallet_BX.TabIndex = 18;
            // 
            // TransactionDel_btn
            // 
            TransactionDel_btn.BackColor = Color.FromArgb(0, 25, 50);
            TransactionDel_btn.Cursor = Cursors.Hand;
            TransactionDel_btn.FlatAppearance.BorderSize = 0;
            TransactionDel_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            TransactionDel_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            TransactionDel_btn.FlatStyle = FlatStyle.Flat;
            TransactionDel_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TransactionDel_btn.ForeColor = Color.White;
            TransactionDel_btn.Location = new Point(340, 159);
            TransactionDel_btn.Margin = new Padding(13, 12, 13, 12);
            TransactionDel_btn.Name = "TransactionDel_btn";
            TransactionDel_btn.Size = new Size(92, 28);
            TransactionDel_btn.TabIndex = 17;
            TransactionDel_btn.Text = "Delete";
            TransactionDel_btn.UseVisualStyleBackColor = false;
            TransactionDel_btn.Click += TransactionDel_btn_Click;
            // 
            // TransactionFilter_btn
            // 
            TransactionFilter_btn.BackColor = Color.FromArgb(0, 25, 50);
            TransactionFilter_btn.Cursor = Cursors.Hand;
            TransactionFilter_btn.FlatAppearance.BorderSize = 0;
            TransactionFilter_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            TransactionFilter_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            TransactionFilter_btn.FlatStyle = FlatStyle.Flat;
            TransactionFilter_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TransactionFilter_btn.ForeColor = Color.White;
            TransactionFilter_btn.Location = new Point(544, 159);
            TransactionFilter_btn.Margin = new Padding(13, 12, 13, 12);
            TransactionFilter_btn.Name = "TransactionFilter_btn";
            TransactionFilter_btn.Size = new Size(92, 28);
            TransactionFilter_btn.TabIndex = 16;
            TransactionFilter_btn.Text = "Filter";
            TransactionFilter_btn.UseVisualStyleBackColor = false;
            TransactionFilter_btn.Click += TransactionFilter_btn_Click;
            // 
            // TransactionAdd_btn
            // 
            TransactionAdd_btn.BackColor = Color.FromArgb(0, 25, 50);
            TransactionAdd_btn.Cursor = Cursors.Hand;
            TransactionAdd_btn.FlatAppearance.BorderSize = 0;
            TransactionAdd_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            TransactionAdd_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            TransactionAdd_btn.FlatStyle = FlatStyle.Flat;
            TransactionAdd_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TransactionAdd_btn.ForeColor = Color.White;
            TransactionAdd_btn.Location = new Point(113, 159);
            TransactionAdd_btn.Margin = new Padding(13, 12, 13, 12);
            TransactionAdd_btn.Name = "TransactionAdd_btn";
            TransactionAdd_btn.Size = new Size(92, 28);
            TransactionAdd_btn.TabIndex = 15;
            TransactionAdd_btn.Text = "Add";
            TransactionAdd_btn.UseVisualStyleBackColor = false;
            TransactionAdd_btn.Click += TransactionAdd_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.875F);
            label2.Location = new Point(38, 39);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 18);
            label2.TabIndex = 14;
            label2.Text = "Currency";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.875F);
            label1.Location = new Point(54, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 18);
            label1.TabIndex = 13;
            label1.Text = "Wallet";
            // 
            // TransactionUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(2, 1, 2, 1);
            Name = "TransactionUI";
            Size = new Size(804, 473);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TransactionList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView TransactionList;
        private Label label3;
        private Panel panel1;
        private DateTimePicker TransactionFilterStartDate_BX;
        private ComboBox TransactionAddCurrency_Bx;
        private ComboBox TransactionAddWallet_BX;
        private Button TransactionDel_btn;
        private Button TransactionFilter_btn;
        private Button TransactionAdd_btn;
        private Label label2;
        private Label label1;
        private ComboBox TransactionAddCategory_BX;
        private Label label5;
        private Label label8;
        private Label label7;
        private DateTimePicker TransactionFilterEndDate_BX;
        private Label label6;
        private TextBox TransactionAddDetails_BX;
        private Label label4;
        private DateTimePicker TransactionAddDateTime;
        private ComboBox TransactionDel_BX;
        private Label label9;
        private ComboBox TransactionFilterWallet_BX;
        private Label label11;
        private ComboBox TransactionFilterType_BX;
        private Label label10;
        private ComboBox TransactionFilterCategory_BX;
        private Label label12;
        private TextBox TransactionAddAmount_BX;
    }
}

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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel2 = new Panel();
            CategoryDataList = new DataGridView();
            label3 = new Label();
            panel1 = new Panel();
            comboBox3 = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label6 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            CategoryTypeBX = new ComboBox();
            CategoryNameBX = new ComboBox();
            CategoryDel_btn = new Button();
            CategoryUpdate_btn = new Button();
            CategoryAdd_btn = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CategoryDataList).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(CategoryDataList);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(30, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(1431, 490);
            panel2.TabIndex = 4;
            // 
            // CategoryDataList
            // 
            CategoryDataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 25, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            CategoryDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            CategoryDataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoryDataList.Location = new Point(29, 103);
            CategoryDataList.Name = "CategoryDataList";
            CategoryDataList.RowHeadersWidth = 82;
            CategoryDataList.Size = new Size(1375, 360);
            CategoryDataList.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(29, 33);
            label3.Name = "label3";
            label3.Size = new Size(276, 45);
            label3.TabIndex = 3;
            label3.Text = "Transaction List";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(CategoryTypeBX);
            panel1.Controls.Add(CategoryNameBX);
            panel1.Controls.Add(CategoryDel_btn);
            panel1.Controls.Add(CategoryUpdate_btn);
            panel1.Controls.Add(CategoryAdd_btn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(30, 547);
            panel1.Name = "panel1";
            panel1.Size = new Size(1431, 425);
            panel1.TabIndex = 5;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(212, 248);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(354, 40);
            comboBox3.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(50, 243);
            label8.Name = "label8";
            label8.Size = new Size(147, 45);
            label8.TabIndex = 28;
            label8.Text = "Amount";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(787, 264);
            label7.Name = "label7";
            label7.Size = new Size(164, 45);
            label7.TabIndex = 27;
            label7.Text = "End date";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(1004, 273);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(400, 39);
            dateTimePicker2.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(787, 201);
            label6.Name = "label6";
            label6.Size = new Size(179, 45);
            label6.TabIndex = 25;
            label6.Text = "Start date";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(212, 191);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(354, 40);
            comboBox1.TabIndex = 24;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(212, 139);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(348, 40);
            comboBox2.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(98, 189);
            label4.Name = "label4";
            label4.Size = new Size(99, 45);
            label4.TabIndex = 22;
            label4.Text = "Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(34, 131);
            label5.Name = "label5";
            label5.Size = new Size(163, 45);
            label5.TabIndex = 21;
            label5.Text = "Category";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1004, 210);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 39);
            dateTimePicker1.TabIndex = 20;
            // 
            // CategoryTypeBX
            // 
            CategoryTypeBX.FormattingEnabled = true;
            CategoryTypeBX.Location = new Point(212, 84);
            CategoryTypeBX.Name = "CategoryTypeBX";
            CategoryTypeBX.Size = new Size(354, 40);
            CategoryTypeBX.TabIndex = 19;
            // 
            // CategoryNameBX
            // 
            CategoryNameBX.FormattingEnabled = true;
            CategoryNameBX.Location = new Point(212, 28);
            CategoryNameBX.Name = "CategoryNameBX";
            CategoryNameBX.Size = new Size(348, 40);
            CategoryNameBX.TabIndex = 18;
            // 
            // CategoryDel_btn
            // 
            CategoryDel_btn.BackColor = Color.FromArgb(0, 25, 50);
            CategoryDel_btn.Cursor = Cursors.Hand;
            CategoryDel_btn.FlatAppearance.BorderSize = 0;
            CategoryDel_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            CategoryDel_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            CategoryDel_btn.FlatStyle = FlatStyle.Flat;
            CategoryDel_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CategoryDel_btn.ForeColor = Color.White;
            CategoryDel_btn.Location = new Point(658, 340);
            CategoryDel_btn.Margin = new Padding(25);
            CategoryDel_btn.Name = "CategoryDel_btn";
            CategoryDel_btn.Size = new Size(170, 60);
            CategoryDel_btn.TabIndex = 17;
            CategoryDel_btn.Text = "Delete";
            CategoryDel_btn.UseVisualStyleBackColor = false;
            // 
            // CategoryUpdate_btn
            // 
            CategoryUpdate_btn.BackColor = Color.FromArgb(0, 25, 50);
            CategoryUpdate_btn.Cursor = Cursors.Hand;
            CategoryUpdate_btn.FlatAppearance.BorderSize = 0;
            CategoryUpdate_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            CategoryUpdate_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            CategoryUpdate_btn.FlatStyle = FlatStyle.Flat;
            CategoryUpdate_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CategoryUpdate_btn.ForeColor = Color.White;
            CategoryUpdate_btn.Location = new Point(1089, 340);
            CategoryUpdate_btn.Margin = new Padding(25);
            CategoryUpdate_btn.Name = "CategoryUpdate_btn";
            CategoryUpdate_btn.Size = new Size(170, 60);
            CategoryUpdate_btn.TabIndex = 16;
            CategoryUpdate_btn.Text = "Update";
            CategoryUpdate_btn.UseVisualStyleBackColor = false;
            // 
            // CategoryAdd_btn
            // 
            CategoryAdd_btn.BackColor = Color.FromArgb(0, 25, 50);
            CategoryAdd_btn.Cursor = Cursors.Hand;
            CategoryAdd_btn.FlatAppearance.BorderSize = 0;
            CategoryAdd_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 50, 255);
            CategoryAdd_btn.FlatAppearance.MouseOverBackColor = Color.Blue;
            CategoryAdd_btn.FlatStyle = FlatStyle.Flat;
            CategoryAdd_btn.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CategoryAdd_btn.ForeColor = Color.White;
            CategoryAdd_btn.Location = new Point(212, 337);
            CategoryAdd_btn.Margin = new Padding(25);
            CategoryAdd_btn.Name = "CategoryAdd_btn";
            CategoryAdd_btn.Size = new Size(170, 60);
            CategoryAdd_btn.TabIndex = 15;
            CategoryAdd_btn.Text = "Add";
            CategoryAdd_btn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(33, 76);
            label2.Name = "label2";
            label2.Size = new Size(164, 45);
            label2.TabIndex = 14;
            label2.Text = "Currency";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(62, 20);
            label1.Name = "label1";
            label1.Size = new Size(119, 45);
            label1.TabIndex = 13;
            label1.Text = "Wallet";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1004, 29);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Write transaction details here.";
            textBox1.Size = new Size(400, 150);
            textBox1.TabIndex = 30;
            // 
            // TransactionUI
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "TransactionUI";
            Size = new Size(1494, 1009);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CategoryDataList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView CategoryDataList;
        private Label label3;
        private Panel panel1;
        private DateTimePicker dateTimePicker1;
        private ComboBox CategoryTypeBX;
        private ComboBox CategoryNameBX;
        private Button CategoryDel_btn;
        private Button CategoryUpdate_btn;
        private Button CategoryAdd_btn;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label4;
        private Label label5;
        private ComboBox comboBox3;
        private Label label8;
        private Label label7;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private TextBox textBox1;
    }
}

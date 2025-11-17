namespace Client
{
    partial class CategoryUI
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            CategoryDataList = new DataGridView();
            label3 = new Label();
            panel1 = new Panel();
            CategoryTypeBX = new ComboBox();
            CategoryNameBX = new ComboBox();
            CategoryDel_btn = new Button();
            CategoryUpdate_btn = new Button();
            CategoryAdd_btn = new Button();
            label2 = new Label();
            label1 = new Label();
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
            panel2.Location = new Point(465, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(1000, 950);
            panel2.TabIndex = 3;
            // 
            // CategoryDataList
            // 
            CategoryDataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 25, 50);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            CategoryDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            CategoryDataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoryDataList.Location = new Point(29, 96);
            CategoryDataList.Name = "CategoryDataList";
            CategoryDataList.RowHeadersWidth = 82;
            CategoryDataList.Size = new Size(945, 820);
            CategoryDataList.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(29, 33);
            label3.Name = "label3";
            label3.Size = new Size(230, 45);
            label3.TabIndex = 3;
            label3.Text = "Category List";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(CategoryTypeBX);
            panel1.Controls.Add(CategoryNameBX);
            panel1.Controls.Add(CategoryDel_btn);
            panel1.Controls.Add(CategoryUpdate_btn);
            panel1.Controls.Add(CategoryAdd_btn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(30, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 950);
            panel1.TabIndex = 2;
            // 
            // CategoryTypeBX
            // 
            CategoryTypeBX.FormattingEnabled = true;
            CategoryTypeBX.Location = new Point(21, 235);
            CategoryTypeBX.Name = "CategoryTypeBX";
            CategoryTypeBX.Size = new Size(354, 40);
            CategoryTypeBX.TabIndex = 12;
            // 
            // CategoryNameBX
            // 
            CategoryNameBX.FormattingEnabled = true;
            CategoryNameBX.Location = new Point(27, 96);
            CategoryNameBX.Name = "CategoryNameBX";
            CategoryNameBX.Size = new Size(348, 40);
            CategoryNameBX.TabIndex = 11;
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
            CategoryDel_btn.Location = new Point(205, 328);
            CategoryDel_btn.Name = "CategoryDel_btn";
            CategoryDel_btn.Size = new Size(170, 60);
            CategoryDel_btn.TabIndex = 10;
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
            CategoryUpdate_btn.Location = new Point(21, 422);
            CategoryUpdate_btn.Name = "CategoryUpdate_btn";
            CategoryUpdate_btn.Size = new Size(354, 60);
            CategoryUpdate_btn.TabIndex = 9;
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
            CategoryAdd_btn.Location = new Point(21, 328);
            CategoryAdd_btn.Name = "CategoryAdd_btn";
            CategoryAdd_btn.Size = new Size(170, 60);
            CategoryAdd_btn.TabIndex = 8;
            CategoryAdd_btn.Text = "Add";
            CategoryAdd_btn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(27, 172);
            label2.Name = "label2";
            label2.Size = new Size(99, 45);
            label2.TabIndex = 4;
            label2.Text = "Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(27, 33);
            label1.Name = "label1";
            label1.Size = new Size(163, 45);
            label1.TabIndex = 2;
            label1.Text = "Category";
            // 
            // CategoryUI
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CategoryUI";
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
        private ComboBox CategoryTypeBX;
        private ComboBox CategoryNameBX;
        private Button CategoryDel_btn;
        private Button CategoryUpdate_btn;
        private Button CategoryAdd_btn;
        private Label label2;
        private Label label1;
    }
}

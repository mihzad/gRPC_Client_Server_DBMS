namespace Client
{
    partial class CreateDBwindow
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
            tableLayoutPanel1 = new TableLayoutPanel();
            CreateDBtextBox = new TextBox();
            CreateDBbutton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.57143F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.8571434F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel1.Controls.Add(CreateDBtextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(CreateDBbutton, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.391304F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21.73913F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.043478F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.434782F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.391304F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // CreateDBtextBox
            // 
            CreateDBtextBox.Dock = DockStyle.Fill;
            CreateDBtextBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            CreateDBtextBox.ForeColor = SystemColors.ActiveCaption;
            CreateDBtextBox.Location = new Point(231, 81);
            CreateDBtextBox.Name = "CreateDBtextBox";
            CreateDBtextBox.Size = new Size(336, 38);
            CreateDBtextBox.TabIndex = 0;
            CreateDBtextBox.Text = "введіть назву нової БД...";
            CreateDBtextBox.TextAlign = HorizontalAlignment.Center;
            CreateDBtextBox.DoubleClick += CreateDBtextBox_DoubleClick;
            // 
            // CreateDBbutton
            // 
            CreateDBbutton.DialogResult = DialogResult.OK;
            CreateDBbutton.Dock = DockStyle.Fill;
            CreateDBbutton.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            CreateDBbutton.ForeColor = Color.IndianRed;
            CreateDBbutton.Location = new Point(231, 236);
            CreateDBbutton.Name = "CreateDBbutton";
            CreateDBbutton.Size = new Size(336, 130);
            CreateDBbutton.TabIndex = 1;
            CreateDBbutton.Text = "Створити";
            CreateDBbutton.UseVisualStyleBackColor = true;
            CreateDBbutton.Click += CreateDBbutton_Click;
            // 
            // CreateDBwindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CreateDBwindow";
            Text = "Створення БД";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox CreateDBtextBox;
        private Button CreateDBbutton;
    }
}
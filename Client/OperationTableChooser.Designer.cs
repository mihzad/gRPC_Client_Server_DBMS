namespace Client
{
    partial class OperationTableChooser
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
            TableChooserList = new ComboBox();
            label1 = new Label();
            OKbutton = new Button();
            SuspendLayout();
            // 
            // TableChooserList
            // 
            TableChooserList.DropDownStyle = ComboBoxStyle.DropDownList;
            TableChooserList.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            TableChooserList.FormattingEnabled = true;
            TableChooserList.Location = new Point(98, 51);
            TableChooserList.Name = "TableChooserList";
            TableChooserList.Size = new Size(283, 31);
            TableChooserList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 128, 128);
            label1.Location = new Point(98, 9);
            label1.Name = "label1";
            label1.Size = new Size(283, 28);
            label1.TabIndex = 1;
            label1.Text = "Виберіть другий операнд...";
            // 
            // OKbutton
            // 
            OKbutton.DialogResult = DialogResult.OK;
            OKbutton.Location = new Point(169, 141);
            OKbutton.Name = "OKbutton";
            OKbutton.Size = new Size(150, 50);
            OKbutton.TabIndex = 2;
            OKbutton.Text = "OK";
            OKbutton.UseVisualStyleBackColor = true;
            OKbutton.Click += OKbutton_Click;
            // 
            // OperationTableChooser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 203);
            Controls.Add(OKbutton);
            Controls.Add(label1);
            Controls.Add(TableChooserList);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "OperationTableChooser";
            StartPosition = FormStartPosition.CenterParent;
            Text = "OperationTableChooser";
            Load += OperationTableChooser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TableChooserList;
        private Label label1;
        private Button OKbutton;
    }
}
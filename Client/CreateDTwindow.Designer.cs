namespace Client
{
    partial class CreateDTwindow
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
            DTnameTextBox = new TextBox();
            DTcolumnsCountTextBox = new TextBox();
            DTokButton = new Button();
            SuspendLayout();
            // 
            // DTnameTextBox
            // 
            DTnameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            DTnameTextBox.ForeColor = SystemColors.WindowText;
            DTnameTextBox.Location = new Point(180, 78);
            DTnameTextBox.Margin = new Padding(10);
            DTnameTextBox.Name = "DTnameTextBox";
            DTnameTextBox.Size = new Size(227, 34);
            DTnameTextBox.TabIndex = 0;
            DTnameTextBox.Text = "введіть ім'я таблиці...";
            DTnameTextBox.DoubleClick += DTnameTextBox_DoubleClick;
            // 
            // DTcolumnsCountTextBox
            // 
            DTcolumnsCountTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            DTcolumnsCountTextBox.Location = new Point(180, 193);
            DTcolumnsCountTextBox.Name = "DTcolumnsCountTextBox";
            DTcolumnsCountTextBox.Size = new Size(227, 34);
            DTcolumnsCountTextBox.TabIndex = 1;
            DTcolumnsCountTextBox.Text = "введіть к-ть колонок...";
            DTcolumnsCountTextBox.DoubleClick += DTcolumnsCountTextBox_DoubleClick;
            // 
            // DTokButton
            // 
            DTokButton.DialogResult = DialogResult.OK;
            DTokButton.Location = new Point(222, 286);
            DTokButton.Name = "DTokButton";
            DTokButton.Size = new Size(140, 50);
            DTokButton.TabIndex = 2;
            DTokButton.Text = "OK";
            DTokButton.UseVisualStyleBackColor = true;
            DTokButton.Click += DTokButton_Click;
            // 
            // CreateDTwindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 372);
            Controls.Add(DTokButton);
            Controls.Add(DTcolumnsCountTextBox);
            Controls.Add(DTnameTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CreateDTwindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Нова таблиця...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DTnameTextBox;
        private TextBox DTcolumnsCountTextBox;
        private Button DTokButton;
    }
}
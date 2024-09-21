namespace Client
{
    partial class EnterColumnDataWindow
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
            CDtextBox = new TextBox();
            label1 = new Label();
            CDokButton = new Button();
            CDddl = new ComboBox();
            SuspendLayout();
            // 
            // CDtextBox
            // 
            CDtextBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            CDtextBox.Location = new Point(193, 75);
            CDtextBox.Name = "CDtextBox";
            CDtextBox.Size = new Size(204, 31);
            CDtextBox.TabIndex = 0;
            CDtextBox.Text = "Введіть назву колонки:";
            CDtextBox.DoubleClick += CDtextBox_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(135, 142);
            label1.Name = "label1";
            label1.Size = new Size(325, 20);
            label1.TabIndex = 2;
            label1.Text = "Виберіть тип підтримуваних даних зі списку:";
            // 
            // CDokButton
            // 
            CDokButton.DialogResult = DialogResult.OK;
            CDokButton.Location = new Point(218, 290);
            CDokButton.Name = "CDokButton";
            CDokButton.Size = new Size(150, 50);
            CDokButton.TabIndex = 3;
            CDokButton.Text = "OK";
            CDokButton.UseVisualStyleBackColor = true;
            CDokButton.Click += CDokButton_Click;
            // 
            // CDddl
            // 
            CDddl.DropDownStyle = ComboBoxStyle.DropDownList;
            CDddl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            CDddl.FormattingEnabled = true;
            CDddl.Location = new Point(218, 176);
            CDddl.Name = "CDddl";
            CDddl.Size = new Size(151, 33);
            CDddl.TabIndex = 4;
            // 
            // EnterColumnDataWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 372);
            Controls.Add(CDddl);
            Controls.Add(CDokButton);
            Controls.Add(label1);
            Controls.Add(CDtextBox);
            Name = "EnterColumnDataWindow";
            StartPosition = FormStartPosition.CenterParent;
            Load += EnterColumnDataWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CDtextBox;
        private Label label1;
        private Button CDokButton;
        private ComboBox CDddl;
    }
}
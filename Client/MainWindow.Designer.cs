namespace Client
{
    partial class MainWindow
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            tableLayoutPanel1 = new TableLayoutPanel();
            toolStrip = new ToolStrip();
            AddDBStripButton = new ToolStripDropDownButton();
            CreateStripItem = new ToolStripMenuItem();
            DownloadStripItem = new ToolStripMenuItem();
            FullMultiplyButton = new ToolStripButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            DBtreeView = new TreeView();
            DBtreeViewImages = new ImageList(components);
            TableDataGridView = new DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            AddTableStripMenuItem = new ToolStripMenuItem();
            DeleteStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            toolStrip.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TableDataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(toolStrip, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.30253363F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.697464F));
            tableLayoutPanel1.Size = new Size(1262, 671);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.Fill;
            toolStrip.ImageScalingSize = new Size(40, 40);
            toolStrip.Items.AddRange(new ToolStripItem[] { AddDBStripButton, FullMultiplyButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1262, 49);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // AddDBStripButton
            // 
            AddDBStripButton.AutoToolTip = false;
            AddDBStripButton.DropDownItems.AddRange(new ToolStripItem[] { CreateStripItem, DownloadStripItem });
            AddDBStripButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
            AddDBStripButton.Image = (Image)resources.GetObject("AddDBStripButton.Image");
            AddDBStripButton.ImageTransparentColor = Color.Magenta;
            AddDBStripButton.Name = "AddDBStripButton";
            AddDBStripButton.Size = new Size(139, 46);
            AddDBStripButton.Text = "Додати БД...";
            // 
            // CreateStripItem
            // 
            CreateStripItem.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            CreateStripItem.Name = "CreateStripItem";
            CreateStripItem.Size = new Size(208, 26);
            CreateStripItem.Text = "створити нову...";
            CreateStripItem.Click += CreateStripItem_Click;
            // 
            // DownloadStripItem
            // 
            DownloadStripItem.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            DownloadStripItem.Name = "DownloadStripItem";
            DownloadStripItem.Size = new Size(208, 26);
            DownloadStripItem.Text = "завантажити...";
            DownloadStripItem.Click += DownloadStripItem_Click;
            // 
            // FullMultiplyButton
            // 
            FullMultiplyButton.Enabled = false;
            FullMultiplyButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
            FullMultiplyButton.Image = (Image)resources.GetObject("FullMultiplyButton.Image");
            FullMultiplyButton.ImageTransparentColor = Color.Magenta;
            FullMultiplyButton.Name = "FullMultiplyButton";
            FullMultiplyButton.Size = new Size(249, 46);
            FullMultiplyButton.Text = "Прямий добуток двох таблиць...";
            FullMultiplyButton.Click += FullMultiplyButton_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.6656055F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.3344F));
            tableLayoutPanel2.Controls.Add(DBtreeView, 0, 0);
            tableLayoutPanel2.Controls.Add(TableDataGridView, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 52);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1256, 616);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // DBtreeView
            // 
            DBtreeView.BackColor = SystemColors.ControlLightLight;
            DBtreeView.Dock = DockStyle.Fill;
            DBtreeView.ImageIndex = 0;
            DBtreeView.ImageList = DBtreeViewImages;
            DBtreeView.ItemHeight = 32;
            DBtreeView.Location = new Point(3, 3);
            DBtreeView.Name = "DBtreeView";
            DBtreeView.SelectedImageIndex = 0;
            DBtreeView.Size = new Size(241, 610);
            DBtreeView.TabIndex = 0;
            DBtreeView.MouseClick += DBtreeView_MouseClick;
            DBtreeView.MouseUp += DBtreeView_MouseUp;
            // 
            // DBtreeViewImages
            // 
            DBtreeViewImages.ColorDepth = ColorDepth.Depth8Bit;
            DBtreeViewImages.ImageStream = (ImageListStreamer)resources.GetObject("DBtreeViewImages.ImageStream");
            DBtreeViewImages.TransparentColor = Color.Transparent;
            DBtreeViewImages.Images.SetKeyName(0, "dbImage.png");
            DBtreeViewImages.Images.SetKeyName(1, "tableImage.png");
            // 
            // TableDataGridView
            // 
            TableDataGridView.BackgroundColor = SystemColors.ControlLight;
            TableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TableDataGridView.Dock = DockStyle.Fill;
            TableDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            TableDataGridView.Location = new Point(250, 3);
            TableDataGridView.MultiSelect = false;
            TableDataGridView.Name = "TableDataGridView";
            TableDataGridView.RowHeadersWidth = 51;
            TableDataGridView.RowTemplate.Height = 29;
            TableDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TableDataGridView.Size = new Size(1003, 610);
            TableDataGridView.TabIndex = 1;
            TableDataGridView.CellDoubleClick += TableDataGridView_CellDoubleClick;
            TableDataGridView.CellValidated += TableDataGridView_CellValidated;
            TableDataGridView.CellValidating += TableDataGridView_CellValidating;
            TableDataGridView.RowsRemoved += TableDataGridView_RowsRemoved;
            TableDataGridView.RowValidated += TableDataGridView_RowValidated;
            TableDataGridView.RowValidating += TableDataGridView_RowValidating;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { AddTableStripMenuItem, DeleteStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(201, 52);
            // 
            // AddTableStripMenuItem
            // 
            AddTableStripMenuItem.Name = "AddTableStripMenuItem";
            AddTableStripMenuItem.Size = new Size(200, 24);
            AddTableStripMenuItem.Text = "додати таблицю...";
            AddTableStripMenuItem.Click += AddTableStripMenuItem_Click;
            // 
            // DeleteStripMenuItem
            // 
            DeleteStripMenuItem.Name = "DeleteStripMenuItem";
            DeleteStripMenuItem.Size = new Size(200, 24);
            DeleteStripMenuItem.Text = "видалити...";
            DeleteStripMenuItem.Click += DeleteStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 671);
            Controls.Add(tableLayoutPanel1);
            Name = "MainWindow";
            Text = "Простенька міні-СУБД";
            FormClosed += MainWindow_FormClosed;
            Load += MainWindow_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TableDataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip;
        private ToolStripButton FullMultiplyButton;
        private TableLayoutPanel tableLayoutPanel2;
        private TreeView DBtreeView;
        private DataGridView TableDataGridView;
        private ToolStripDropDownButton AddDBStripButton;
        private ToolStripMenuItem CreateStripItem;
        private ToolStripMenuItem DownloadStripItem;
        private ImageList DBtreeViewImages;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem DeleteStripMenuItem;
        private ToolStripMenuItem AddTableStripMenuItem;
    }
}
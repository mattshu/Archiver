using System.Windows.Forms;

namespace Archiver
{
    partial class ArchiverMainWindow
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
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.dateFilterDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblByExtension = new System.Windows.Forms.Label();
            this.txtFilterByExtension = new System.Windows.Forms.TextBox();
            this.chkFilterByExtension = new System.Windows.Forms.CheckBox();
            this.radNewerThan = new System.Windows.Forms.RadioButton();
            this.radOlderThan = new System.Windows.Forms.RadioButton();
            this.chkIncludeSubDirs = new System.Windows.Forms.CheckBox();
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.cbxSearchStyle = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslblFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsseparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateAccessed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxOpenFileLocation,
            this.ctxOpenFile});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(169, 48);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // ctxOpenFileLocation
            // 
            this.ctxOpenFileLocation.Name = "ctxOpenFileLocation";
            this.ctxOpenFileLocation.Size = new System.Drawing.Size(168, 22);
            this.ctxOpenFileLocation.Text = "Open file location";
            // 
            // ctxOpenFile
            // 
            this.ctxOpenFile.Name = "ctxOpenFile";
            this.ctxOpenFile.Size = new System.Drawing.Size(168, 22);
            this.ctxOpenFile.Text = "Open file";
            // 
            // dateFilterDate
            // 
            this.dateFilterDate.CustomFormat = "MM/dd/yyyy h:mm tt";
            this.dateFilterDate.Enabled = false;
            this.dateFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFilterDate.Location = new System.Drawing.Point(394, 46);
            this.dateFilterDate.Name = "dateFilterDate";
            this.dateFilterDate.Size = new System.Drawing.Size(146, 20);
            this.dateFilterDate.TabIndex = 3;
            this.dateFilterDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFile,
            this.colExtension,
            this.colSize,
            this.colDateModified,
            this.colDateAccessed,
            this.colDateCreated,
            this.colPath});
            this.dataGridView.ContextMenuStrip = this.contextMenu;
            this.dataGridView.Location = new System.Drawing.Point(3, 102);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1040, 445);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnExport);
            this.panelTop.Controls.Add(this.btnScan);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.MinimumSize = new System.Drawing.Size(700, 43);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1047, 96);
            this.panelTop.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(9, 54);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(927, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(108, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(927, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExport.Size = new System.Drawing.Size(108, 34);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScan.Location = new System.Drawing.Point(9, 11);
            this.btnScan.Name = "btnScan";
            this.btnScan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnScan.Size = new System.Drawing.Size(108, 34);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan Directory...";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblByExtension);
            this.groupBox1.Controls.Add(this.txtFilterByExtension);
            this.groupBox1.Controls.Add(this.chkFilterByExtension);
            this.groupBox1.Controls.Add(this.radNewerThan);
            this.groupBox1.Controls.Add(this.dateFilterDate);
            this.groupBox1.Controls.Add(this.radOlderThan);
            this.groupBox1.Controls.Add(this.chkIncludeSubDirs);
            this.groupBox1.Controls.Add(this.chkFilter);
            this.groupBox1.Controls.Add(this.cbxSearchStyle);
            this.groupBox1.Location = new System.Drawing.Point(123, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 85);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lblByExtension
            // 
            this.lblByExtension.AutoSize = true;
            this.lblByExtension.Enabled = false;
            this.lblByExtension.Location = new System.Drawing.Point(394, 18);
            this.lblByExtension.Name = "lblByExtension";
            this.lblByExtension.Size = new System.Drawing.Size(98, 13);
            this.lblByExtension.TabIndex = 11;
            this.lblByExtension.Text = "(*.txt, *.doc, *.docx)";
            // 
            // txtFilterByExtension
            // 
            this.txtFilterByExtension.Enabled = false;
            this.txtFilterByExtension.Location = new System.Drawing.Point(228, 15);
            this.txtFilterByExtension.Name = "txtFilterByExtension";
            this.txtFilterByExtension.Size = new System.Drawing.Size(160, 20);
            this.txtFilterByExtension.TabIndex = 10;
            this.txtFilterByExtension.Text = "*.*";
            // 
            // chkFilterByExtension
            // 
            this.chkFilterByExtension.AutoSize = true;
            this.chkFilterByExtension.Enabled = false;
            this.chkFilterByExtension.Location = new System.Drawing.Point(143, 18);
            this.chkFilterByExtension.Name = "chkFilterByExtension";
            this.chkFilterByExtension.Size = new System.Drawing.Size(87, 17);
            this.chkFilterByExtension.TabIndex = 9;
            this.chkFilterByExtension.Text = "By Extension";
            this.chkFilterByExtension.UseVisualStyleBackColor = true;
            this.chkFilterByExtension.CheckedChanged += new System.EventHandler(this.chkFilterByExtension_CheckedChanged);
            // 
            // radNewerThan
            // 
            this.radNewerThan.AutoSize = true;
            this.radNewerThan.Enabled = false;
            this.radNewerThan.Location = new System.Drawing.Point(308, 49);
            this.radNewerThan.Name = "radNewerThan";
            this.radNewerThan.Size = new System.Drawing.Size(80, 17);
            this.radNewerThan.TabIndex = 8;
            this.radNewerThan.Text = "Newer than";
            this.radNewerThan.UseVisualStyleBackColor = true;
            // 
            // radOlderThan
            // 
            this.radOlderThan.AutoSize = true;
            this.radOlderThan.Checked = true;
            this.radOlderThan.Enabled = false;
            this.radOlderThan.Location = new System.Drawing.Point(228, 49);
            this.radOlderThan.Name = "radOlderThan";
            this.radOlderThan.Size = new System.Drawing.Size(74, 17);
            this.radOlderThan.TabIndex = 8;
            this.radOlderThan.TabStop = true;
            this.radOlderThan.Text = "Older than";
            this.radOlderThan.UseVisualStyleBackColor = true;
            this.radOlderThan.CheckedChanged += new System.EventHandler(this.radOlderThan_CheckedChanged);
            // 
            // chkIncludeSubDirs
            // 
            this.chkIncludeSubDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeSubDirs.AutoSize = true;
            this.chkIncludeSubDirs.Checked = true;
            this.chkIncludeSubDirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSubDirs.Location = new System.Drawing.Point(6, 19);
            this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
            this.chkIncludeSubDirs.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubDirs.TabIndex = 5;
            this.chkIncludeSubDirs.Text = "Include Subdirectories";
            this.chkIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Location = new System.Drawing.Point(7, 50);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(48, 17);
            this.chkFilter.TabIndex = 6;
            this.chkFilter.Text = "Filter";
            this.chkFilter.UseVisualStyleBackColor = true;
            this.chkFilter.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
            // 
            // cbxSearchStyle
            // 
            this.cbxSearchStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchStyle.Enabled = false;
            this.cbxSearchStyle.FormattingEnabled = true;
            this.cbxSearchStyle.Items.AddRange(new object[] {
            "Date Modified",
            "Date Accessed",
            "Date Created"});
            this.cbxSearchStyle.Location = new System.Drawing.Point(61, 45);
            this.cbxSearchStyle.Name = "cbxSearchStyle";
            this.cbxSearchStyle.Size = new System.Drawing.Size(160, 21);
            this.cbxSearchStyle.TabIndex = 7;
            this.cbxSearchStyle.SelectedIndexChanged += new System.EventHandler(this.cbxSearchStyle_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblFileCount,
            this.tsseparator1,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 553);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1047, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip";
            // 
            // tslblFileCount
            // 
            this.tslblFileCount.Name = "tslblFileCount";
            this.tslblFileCount.Size = new System.Drawing.Size(0, 17);
            // 
            // tsseparator1
            // 
            this.tsseparator1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsseparator1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsseparator1.Name = "tsseparator1";
            this.tsseparator1.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // colFile
            // 
            this.colFile.DataPropertyName = "Name";
            this.colFile.HeaderText = "Filename";
            this.colFile.Name = "colFile";
            this.colFile.ReadOnly = true;
            this.colFile.Width = 150;
            // 
            // colExtension
            // 
            this.colExtension.DataPropertyName = "Extension";
            this.colExtension.HeaderText = "Extension";
            this.colExtension.Name = "colExtension";
            this.colExtension.ReadOnly = true;
            this.colExtension.Width = 75;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "Size";
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 75;
            // 
            // colDateModified
            // 
            this.colDateModified.DataPropertyName = "DateModified";
            this.colDateModified.HeaderText = "Date Modified";
            this.colDateModified.Name = "colDateModified";
            this.colDateModified.ReadOnly = true;
            this.colDateModified.Width = 125;
            // 
            // colDateAccessed
            // 
            this.colDateAccessed.DataPropertyName = "DateAccessed";
            this.colDateAccessed.HeaderText = "Date Accessed";
            this.colDateAccessed.Name = "colDateAccessed";
            this.colDateAccessed.ReadOnly = true;
            this.colDateAccessed.Width = 125;
            // 
            // colDateCreated
            // 
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.HeaderText = "Date Created";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            this.colDateCreated.Width = 125;
            // 
            // colPath
            // 
            this.colPath.DataPropertyName = "Path";
            this.colPath.HeaderText = "Path";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            this.colPath.Width = 350;
            // 
            // ArchiverMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 575);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(750, 255);
            this.Name = "ArchiverMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archiver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiverMainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.ArchiverMainWindow_Shown);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DateTimePicker dateFilterDate;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox chkIncludeSubDirs;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxOpenFileLocation;
        private ToolStripMenuItem ctxOpenFile;
        private Button btnRefresh;
        private DataGridView dataGridView;
        private RadioButton radNewerThan;
        private RadioButton radOlderThan;
        private ComboBox cbxSearchStyle;
        private CheckBox chkFilter;
        private ToolStripStatusLabel tslblFileCount;
        private ToolStripStatusLabel tsseparator1;
        private GroupBox groupBox1;
        private Button btnClose;
        private Button btnExport;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label lblByExtension;
        private TextBox txtFilterByExtension;
        private CheckBox chkFilterByExtension;
        private DataGridViewTextBoxColumn colFile;
        private DataGridViewTextBoxColumn colExtension;
        private DataGridViewTextBoxColumn colSize;
        private DataGridViewTextBoxColumn colDateModified;
        private DataGridViewTextBoxColumn colDateAccessed;
        private DataGridViewTextBoxColumn colDateCreated;
        private DataGridViewTextBoxColumn colPath;
    }
}


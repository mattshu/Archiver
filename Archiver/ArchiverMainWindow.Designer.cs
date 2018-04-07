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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateAccessed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExportList = new System.Windows.Forms.Button();
            this.btnRemoveAllFiles = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNewerThan = new System.Windows.Forms.RadioButton();
            this.radOlderThan = new System.Windows.Forms.RadioButton();
            this.chkIncludeSubDirs = new System.Windows.Forms.CheckBox();
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.cbxSearchStyle = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslblFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsseparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnQuarantine = new System.Windows.Forms.Button();
            this.btnQuarantineSelected = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
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
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "MM/dd/yyyy h:mm tt";
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(312, 43);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(146, 20);
            this.dateTimePicker.TabIndex = 3;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
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
            // colFile
            // 
            this.colFile.DataPropertyName = "Name";
            this.colFile.HeaderText = "File";
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
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnRemoveSelected);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnQuarantineSelected);
            this.panelTop.Controls.Add(this.btnQuarantine);
            this.panelTop.Controls.Add(this.btnExportList);
            this.panelTop.Controls.Add(this.btnRemoveAllFiles);
            this.panelTop.Controls.Add(this.btnScan);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Location = new System.Drawing.Point(3, 5);
            this.panelTop.MinimumSize = new System.Drawing.Size(700, 43);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1040, 83);
            this.panelTop.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(9, 46);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveSelected.Enabled = false;
            this.btnRemoveSelected.Location = new System.Drawing.Point(594, 40);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRemoveSelected.Size = new System.Drawing.Size(143, 34);
            this.btnRemoveSelected.TabIndex = 1;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(892, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(143, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExportList
            // 
            this.btnExportList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportList.Enabled = false;
            this.btnExportList.Location = new System.Drawing.Point(892, 3);
            this.btnExportList.Name = "btnExportList";
            this.btnExportList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExportList.Size = new System.Drawing.Size(143, 34);
            this.btnExportList.TabIndex = 1;
            this.btnExportList.Text = "Export As List...";
            this.btnExportList.UseVisualStyleBackColor = true;
            this.btnExportList.Click += new System.EventHandler(this.btnExportAsList_Click);
            // 
            // btnRemoveAllFiles
            // 
            this.btnRemoveAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAllFiles.Enabled = false;
            this.btnRemoveAllFiles.Location = new System.Drawing.Point(594, 3);
            this.btnRemoveAllFiles.Name = "btnRemoveAllFiles";
            this.btnRemoveAllFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRemoveAllFiles.Size = new System.Drawing.Size(143, 34);
            this.btnRemoveAllFiles.TabIndex = 1;
            this.btnRemoveAllFiles.Text = "Remove All Files";
            this.btnRemoveAllFiles.UseVisualStyleBackColor = true;
            this.btnRemoveAllFiles.Click += new System.EventHandler(this.btnRemoveAllFiles_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScan.Location = new System.Drawing.Point(9, 7);
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
            this.groupBox1.Controls.Add(this.radNewerThan);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.radOlderThan);
            this.groupBox1.Controls.Add(this.chkIncludeSubDirs);
            this.groupBox1.Controls.Add(this.chkFilter);
            this.groupBox1.Controls.Add(this.cbxSearchStyle);
            this.groupBox1.Location = new System.Drawing.Point(123, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 80);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // radNewerThan
            // 
            this.radNewerThan.AutoSize = true;
            this.radNewerThan.Enabled = false;
            this.radNewerThan.Location = new System.Drawing.Point(226, 57);
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
            this.radOlderThan.Location = new System.Drawing.Point(226, 34);
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
            this.chkIncludeSubDirs.Location = new System.Drawing.Point(6, 13);
            this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
            this.chkIncludeSubDirs.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubDirs.TabIndex = 5;
            this.chkIncludeSubDirs.Text = "Include Subdirectories";
            this.chkIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Location = new System.Drawing.Point(6, 48);
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
            this.cbxSearchStyle.Location = new System.Drawing.Point(60, 43);
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
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
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
            // btnQuarantine
            // 
            this.btnQuarantine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuarantine.Enabled = false;
            this.btnQuarantine.Location = new System.Drawing.Point(743, 3);
            this.btnQuarantine.Name = "btnQuarantine";
            this.btnQuarantine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnQuarantine.Size = new System.Drawing.Size(143, 34);
            this.btnQuarantine.TabIndex = 1;
            this.btnQuarantine.Text = "Quarantine All Files";
            this.btnQuarantine.UseVisualStyleBackColor = true;
            this.btnQuarantine.Click += new System.EventHandler(this.btnQuarantine_Click);
            // 
            // btnQuarantineSelected
            // 
            this.btnQuarantineSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuarantineSelected.Enabled = false;
            this.btnQuarantineSelected.Location = new System.Drawing.Point(743, 40);
            this.btnQuarantineSelected.Name = "btnQuarantineSelected";
            this.btnQuarantineSelected.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnQuarantineSelected.Size = new System.Drawing.Size(143, 34);
            this.btnQuarantineSelected.TabIndex = 1;
            this.btnQuarantineSelected.Text = "Quarantine Selected";
            this.btnQuarantineSelected.UseVisualStyleBackColor = true;
            this.btnQuarantineSelected.Click += new System.EventHandler(this.btnQuarantineSelected_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
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
        private System.Windows.Forms.DateTimePicker dateTimePicker;
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
        private Button btnRemoveAllFiles;
        private Button btnRemoveSelected;
        private Button btnClose;
        private Button btnExportList;
        private DataGridViewTextBoxColumn colFile;
        private DataGridViewTextBoxColumn colExtension;
        private DataGridViewTextBoxColumn colSize;
        private DataGridViewTextBoxColumn colDateModified;
        private DataGridViewTextBoxColumn colDateAccessed;
        private DataGridViewTextBoxColumn colDateCreated;
        private DataGridViewTextBoxColumn colPath;
        private Button btnQuarantineSelected;
        private Button btnQuarantine;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}


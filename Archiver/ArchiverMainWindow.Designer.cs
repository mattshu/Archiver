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
            this.radFilesOlderThan = new System.Windows.Forms.RadioButton();
            this.radFilesUntouchedSince = new System.Windows.Forms.RadioButton();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnStop = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateAccessed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop = new System.Windows.Forms.Panel();
            this.chkIncludeSubDirs = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelTop.SuspendLayout();
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
            // radFilesOlderThan
            // 
            this.radFilesOlderThan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radFilesOlderThan.AutoSize = true;
            this.radFilesOlderThan.Checked = true;
            this.radFilesOlderThan.Location = new System.Drawing.Point(171, 3);
            this.radFilesOlderThan.Name = "radFilesOlderThan";
            this.radFilesOlderThan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radFilesOlderThan.Size = new System.Drawing.Size(114, 17);
            this.radFilesOlderThan.TabIndex = 2;
            this.radFilesOlderThan.TabStop = true;
            this.radFilesOlderThan.Text = "for Files older than:";
            this.radFilesOlderThan.UseVisualStyleBackColor = true;
            // 
            // radFilesUntouchedSince
            // 
            this.radFilesUntouchedSince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radFilesUntouchedSince.AutoSize = true;
            this.radFilesUntouchedSince.Location = new System.Drawing.Point(139, 20);
            this.radFilesUntouchedSince.Name = "radFilesUntouchedSince";
            this.radFilesUntouchedSince.Size = new System.Drawing.Size(146, 17);
            this.radFilesUntouchedSince.TabIndex = 2;
            this.radFilesUntouchedSince.Text = "for Files untouched since:";
            this.radFilesUntouchedSince.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker.Location = new System.Drawing.Point(291, 8);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(887, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 34);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Location = new System.Drawing.Point(0, 43);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(970, 354);
            this.panelBottom.TabIndex = 5;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
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
            this.dataGridView.Location = new System.Drawing.Point(3, 48);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(970, 351);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            // 
            // colFile
            // 
            this.colFile.DataPropertyName = "Name";
            this.colFile.Frozen = true;
            this.colFile.HeaderText = "File";
            this.colFile.Name = "colFile";
            this.colFile.ReadOnly = true;
            this.colFile.Width = 150;
            // 
            // colExtension
            // 
            this.colExtension.DataPropertyName = "Extension";
            this.colExtension.Frozen = true;
            this.colExtension.HeaderText = "Extension";
            this.colExtension.Name = "colExtension";
            this.colExtension.ReadOnly = true;
            this.colExtension.Width = 75;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "Size";
            this.colSize.Frozen = true;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 75;
            // 
            // colDateModified
            // 
            this.colDateModified.DataPropertyName = "DateModified";
            this.colDateModified.Frozen = true;
            this.colDateModified.HeaderText = "Date Modified";
            this.colDateModified.Name = "colDateModified";
            this.colDateModified.ReadOnly = true;
            this.colDateModified.Width = 125;
            // 
            // colDateAccessed
            // 
            this.colDateAccessed.DataPropertyName = "DateAccessed";
            this.colDateAccessed.Frozen = true;
            this.colDateAccessed.HeaderText = "Date Accessed";
            this.colDateAccessed.Name = "colDateAccessed";
            this.colDateAccessed.ReadOnly = true;
            this.colDateAccessed.Width = 125;
            // 
            // colDateCreated
            // 
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.Frozen = true;
            this.colDateCreated.HeaderText = "Date Created";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            this.colDateCreated.Width = 125;
            // 
            // colPath
            // 
            this.colPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPath.DataPropertyName = "Path";
            this.colPath.HeaderText = "Path";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.chkIncludeSubDirs);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnStop);
            this.panelTop.Controls.Add(this.panelBottom);
            this.panelTop.Controls.Add(this.dateTimePicker);
            this.panelTop.Controls.Add(this.btnScan);
            this.panelTop.Controls.Add(this.radFilesOlderThan);
            this.panelTop.Controls.Add(this.radFilesUntouchedSince);
            this.panelTop.Location = new System.Drawing.Point(3, 5);
            this.panelTop.MinimumSize = new System.Drawing.Size(700, 43);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(970, 43);
            this.panelTop.TabIndex = 6;
            // 
            // chkIncludeSubDirs
            // 
            this.chkIncludeSubDirs.AutoSize = true;
            this.chkIncludeSubDirs.Checked = true;
            this.chkIncludeSubDirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSubDirs.Location = new System.Drawing.Point(512, 13);
            this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
            this.chkIncludeSubDirs.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubDirs.TabIndex = 5;
            this.chkIncludeSubDirs.Text = "Include Subdirectories";
            this.chkIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(806, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScan.Location = new System.Drawing.Point(9, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnScan.Size = new System.Drawing.Size(108, 34);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan Directory...";
            this.btnScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 405);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(977, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip";
            // 
            // ArchiverMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 427);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(750, 255);
            this.Name = "ArchiverMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archiver";
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.RadioButton radFilesOlderThan;
        private System.Windows.Forms.RadioButton radFilesUntouchedSince;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox chkIncludeSubDirs;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxOpenFileLocation;
        private ToolStripMenuItem ctxOpenFile;
        private Button btnRefresh;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn colFile;
        private DataGridViewTextBoxColumn colExtension;
        private DataGridViewTextBoxColumn colSize;
        private DataGridViewTextBoxColumn colDateModified;
        private DataGridViewTextBoxColumn colDateAccessed;
        private DataGridViewTextBoxColumn colDateCreated;
        private DataGridViewTextBoxColumn colPath;
    }
}


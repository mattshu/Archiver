using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archiver {
    public partial class ArchiverMainWindow : Form {

        private SortOrder sortOrder = SortOrder.Ascending;
        private List<FileData> fileList = new List<FileData>();
        public SearchStyle searchStyle { get; private set; } = SearchStyle.ForFilesOlderThan;
        public SearchConditions searchConditions { get; private set; }



        private void btnScan_Click(object sender, EventArgs e) {
            BuildNewFileList();
            LoadItemsFromFileList();
            btnRefresh.Enabled = true;  // TODO TEMP
        }

        private void BuildNewFileList() { 
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            SetSearchConditions();
            var selectedPath = folderBrowserDialog.SelectedPath;
            var getFileListForm = new GetFileListForm(selectedPath, searchConditions);
            if (getFileListForm.ShowDialog() != DialogResult.OK || getFileListForm.fileList.Count <= 0) return;
            fileList = getFileListForm.fileList;
        }

        private void SetSearchConditions() {
            searchConditions = new SearchConditions {
                Style = searchStyle,
                Date = dateTimePicker.Value,
                Option = chkIncludeSubDirs.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
            };
        }

        private void LoadItemsFromFileList() {
            if (fileList.Count <= 0) return;
            dataGridView.DataSource = null;
            BuildDataGridViewColumns();
            dataGridView.DataSource = fileList;

        }
        private void BuildDataGridViewColumns() {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;
            colFile = new DataGridViewTextBoxColumn {
                DataPropertyName = "Name",
                Name = "File",
                Width = 150
            };
            colExtension = new DataGridViewTextBoxColumn {
                DataPropertyName = "Extension",
                Name = "Extension",
                Width = 75
            };
            colSize = new DataGridViewTextBoxColumn {
                DataPropertyName = "Size",
                Name = "Size",
                Width = 75
            };
            colDateModified = new DataGridViewTextBoxColumn {
                DataPropertyName = "DateModified",
                Name = "Date Modified",
                Width = 125
            };
            colDateAccessed = new DataGridViewTextBoxColumn {
                DataPropertyName = "DateAccessed",
                Name = "Date Accessed",
                Width = 125
            };
            colDateCreated = new DataGridViewTextBoxColumn {
                DataPropertyName = "DateCreated",
                Name = "Date Created",
                Width = 125
            };
            colPath = new DataGridViewTextBoxColumn {
                DataPropertyName = "Path",
                Name = "Path",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView.Columns.AddRange(colFile, colExtension, colSize, colDateModified, colDateAccessed, colDateCreated, colPath);
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            //refreshFileList();
            btnRefresh.Enabled = false; // TODO TEMP
        }


        public ArchiverMainWindow() {
            InitializeComponent();
        }
        

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (dataGridView.SelectedRows.Count <= 0) return;
            string name = (string)dataGridView.SelectedRows[0].Cells["File"].Value;
            string path = (string)dataGridView.SelectedRows[0].Cells["Path"].Value;
            if (e.ClickedItem == ctxOpenFileLocation) {
                Process.Start("explorer.exe", path);
            }
            else if (e.ClickedItem == ctxOpenFile) {
                string pathToFile = path + "\\" + name;
                Process.Start("explorer.exe", pathToFile);
            }
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            sortOrder = sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            var fileDataComparer = new FileDataComparer((ColumnType)e.ColumnIndex, sortOrder);
            fileList.Sort(fileDataComparer);
            dataGridView.Refresh();
        }

        private void RefreshDataGridView() {
            
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e) {
            if (dataGridView.SelectedRows.Count <= 0)
                e.Cancel = true;
        }

        /*private void radFilesOlderThan_CheckedChanged(object sender, EventArgs e) {
            searchStyle = radFilesOlderThan.Checked ? SearchStyle.ForFilesOlderThan : SearchStyle.ForFilesUntouchedSince;
            if (dataGridView.Items.Count > 0)
                btnRefresh.Enabled = true;  // TODO TEMP
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e) {
            if (dataGridView.Items.Count > 0)
                btnRefresh.Enabled = true;  // TODO TEMP
        }*/
    }
}
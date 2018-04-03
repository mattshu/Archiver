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
        private string parentFolder;

        private void BuildNewFileList() {
            parentFolder = SetParentFolder();
            if (parentFolder == null) return;
            SetSearchConditions();
            BuildFileList();
        }

        private void BuildFileList() {
            var getFileListForm = new GetFileListForm(parentFolder, searchConditions);
            if (getFileListForm.ShowDialog() != DialogResult.OK || getFileListForm.fileList.Count <= 0) return;
            fileList = getFileListForm.fileList;
        }

        private string SetParentFolder() {
            folderBrowserDialog = new FolderBrowserDialog();
            return folderBrowserDialog.ShowDialog() != DialogResult.OK ? null : folderBrowserDialog.SelectedPath;
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
            btnRefresh.Enabled = true; // TODO TEMP
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
                Width = 252
            };
            dataGridView.Columns.AddRange(colFile, colExtension, colSize, colDateModified, colDateAccessed,
                colDateCreated, colPath);
        }

        private void btnScan_Click(object sender, EventArgs e) {
            BuildNewFileList();
            LoadItemsFromFileList();
        }
        private void btnRefresh_Click(object sender, EventArgs e) {
            RefreshDataGridView();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (dataGridView.SelectedRows.Count <= 0) return;
            string name = (string) dataGridView.SelectedRows[0].Cells["File"].Value;
            string path = (string) dataGridView.SelectedRows[0].Cells["Path"].Value;
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
            var fileDataComparer = new FileDataComparer((ColumnType) e.ColumnIndex, sortOrder);
            fileList.Sort(fileDataComparer);
            dataGridView.Refresh();
        }

        private void RefreshDataGridView() {
            SetSearchConditions();
            BuildFileList();
            LoadItemsFromFileList();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e) {
            e.Cancel = dataGridView.SelectedRows.Count <= 0;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e) {
            btnRefresh.Enabled = ListHasItems();
        }

        private bool ListHasItems() {
            return dataGridView.RowCount > 0;
        }

        private void radFilesOlderThan_CheckedChanged(object sender, EventArgs e) {
            SetSearchStyle();
            btnRefresh.Enabled = ListHasItems();
        }

        private void SetSearchStyle() {
            searchStyle = radFilesOlderThan.Checked ? SearchStyle.ForFilesOlderThan : SearchStyle.ForFilesUntouchedSince;
        }

        public ArchiverMainWindow() {
            InitializeComponent();
        }
    }
}
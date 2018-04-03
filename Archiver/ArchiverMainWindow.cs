using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Archiver {
    public partial class ArchiverMainWindow : Form {

        public SearchFilter searchFilter;

        private List<FileData> fileList = new List<FileData>();
        private string parentFolder;
        private SortOrder sortOrder = SortOrder.Ascending;
        
        private void btnScan_Click(object sender, EventArgs e) {
            BuildNewFileList();
            LoadItemsFromFileList();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            RefreshDataGridView();
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            sortOrder = sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            var fileDataComparer = new FileDataComparer((ColumnType)e.ColumnIndex, sortOrder);
            fileList.Sort(fileDataComparer);
            dataGridView.Refresh();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e) {
            btnRefresh.Enabled = DataListHasItems();
        }

        private void radOlderThan_CheckedChanged(object sender, EventArgs e) {
            searchFilter.Period = GetSearchPeriod();
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e) {
            EnableFilterControls(chkFilter.Checked);
        }

        private void EnableFilterControls(bool condition) {
            cbxSearchStyle.Enabled = condition;
            radOlderThan.Enabled = condition;
            radNewerThan.Enabled = condition;
            dateTimePicker.Enabled = condition;
        }

        private void cbxSearchStyle_SelectedIndexChanged(object sender, EventArgs e) {
            Debug.WriteLine(sender.GetType());
            searchFilter.Style = GetSearchStyle();
            btnRefresh.Enabled = DataListHasItems();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (dataGridView.SelectedRows.Count <= 0) return;
            var name = (string) dataGridView.SelectedRows[0].Cells["File"].Value;
            var path = (string) dataGridView.SelectedRows[0].Cells["Path"].Value;
            if (e.ClickedItem == ctxOpenFileLocation) {
                Process.Start("explorer.exe", path);
            }
            else if (e.ClickedItem == ctxOpenFile) {
                var pathToFile = path + "\\" + name;
                Process.Start("explorer.exe", pathToFile);
            }
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e) {
            e.Cancel = dataGridView.SelectedRows.Count <= 0;
        }

        private void RefreshDataGridView() {
            SetSearchFilter();
            BuildFileList();
            LoadItemsFromFileList();
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

        private bool DataListHasItems() {
            return dataGridView.RowCount > 0;
        }

        private string SetParentFolder() {
            folderBrowserDialog = new FolderBrowserDialog();
            return folderBrowserDialog.ShowDialog() != DialogResult.OK ? null : folderBrowserDialog.SelectedPath;
        }

        private void SetSearchFilter() {
            searchFilter = new SearchFilter {
                Style = GetSearchStyle(),
                Period = GetSearchPeriod(),
                Date = dateTimePicker.Value,
                Option = GetSearchOption(),
                Enabled = chkFilter.Checked
            };
        }

        private SearchStyle GetSearchStyle() {
            return (SearchStyle) cbxSearchStyle.SelectedIndex;
        }

        private SearchPeriod GetSearchPeriod() {
            return radOlderThan.Checked ? SearchPeriod.OlderThan : SearchPeriod.NewerThan;
        }

        private SearchOption GetSearchOption() {
            return chkIncludeSubDirs.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        }

        private void BuildNewFileList() {
            var tryParentFolder = SetParentFolder();
            if (tryParentFolder == null) return;
            parentFolder = tryParentFolder;
            SetSearchFilter();
            BuildFileList();
        }

        private void BuildFileList() {
            var getFileListForm = new GetFileListForm(parentFolder, searchFilter);
            if (getFileListForm.ShowDialog() != DialogResult.OK || getFileListForm.fileList.Count <= 0) return;
            fileList = getFileListForm.fileList;
        }

        private void LoadItemsFromFileList() {
            if (fileList.Count <= 0) return;
            dataGridView.DataSource = null;
            BuildDataGridViewColumns();
            dataGridView.DataSource = fileList;
            btnRefresh.Enabled = true; // TODO TEMP
        }

        public ArchiverMainWindow() {
            InitializeComponent();
            searchFilter = new SearchFilter();
        }

        private void ArchiverMainWindow_Shown(object sender, EventArgs e) {
            cbxSearchStyle.SelectedIndex = 0;
        }
    }
}
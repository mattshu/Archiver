using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Archiver {
    public partial class ArchiverMainWindow : Form {

        private SearchFilter searchFilter;

        private List<FileData> fileList = new List<FileData>();
        private string parentFolder;
        private SortOrder sortOrder = SortOrder.Ascending;

        private void ArchiverMainWindow_Shown(object sender, EventArgs e) {
            cbxSearchStyle.SelectedIndex = 0;
            LoadColumnWidths();
        }

        private void ArchiverMainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            SaveColumnWidths();
        }

        private void btnScan_Click(object sender, EventArgs e) {
            BuildNewFileList();
            LoadItemsFromFileList();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            fileList = new List<FileData>();
            RefreshDataGridView();
        }

        private void btnRemoveAllFiles_Click(object sender, EventArgs e) {
            const string removeConfirmText = "Are you sure you wish to remove all files? This cannot be undone.";
            if (!ConfirmDialog(removeConfirmText)) return;
            foreach (var file in fileList.ToList()) {
                try {
                    File.SetAttributes(file.GetFilePath(), FileAttributes.Normal);
                    File.Delete(file.GetFilePath());
                    fileList.Remove(file);
                }
                catch (Exception) {
                    // Undeletable files will be leftover
                }
            }
            LoadItemsFromFileList();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e) {

        }

        private void btnQuarantine_Click(object sender, EventArgs e) {

        }

        private void btnQuarantineSelected_Click(object sender, EventArgs e) {
            
        }

        private bool ConfirmDialog(string msg, string title = "Confirm") {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) ==
                   DialogResult.Yes;
        }

        private void btnExportAsList_Click(object sender, EventArgs e) {

        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
        
        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            sortOrder = sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            var fileDataComparer = new FileDataComparer((ColumnType)e.ColumnIndex, sortOrder);
            fileList.Sort(fileDataComparer);
            dataGridView.Refresh();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e) {
            btnRefresh.Enabled = true;
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
            searchFilter.Style = GetSearchStyle();
            btnRefresh.Enabled = DataListHasItems();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (dataGridView.SelectedRows.Count <= 0) return;
            var name = (string) dataGridView.SelectedRows[0].Cells["File"].Value;
            var path = (string) dataGridView.SelectedRows[0].Cells["Path"].Value;
            if (e.ClickedItem == ctxOpenFileLocation) {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            else if (e.ClickedItem == ctxOpenFile) {
                var pathToFile = path + "\\" + name;
                System.Diagnostics.Process.Start("explorer.exe", pathToFile);
            }
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e) {
            e.Cancel = dataGridView.SelectedRows.Count <= 0;
        }

        private void RefreshDataGridView() {
            SetSearchFilter();
            BuildFileListFromParentFolder();
            LoadItemsFromFileList();
        }

        private void BuildDataGridViewColumns() {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;
            colFile = new DataGridViewTextBoxColumn { DataPropertyName = "Name", Name = "File" };
            colExtension = new DataGridViewTextBoxColumn { DataPropertyName = "Extension", Name = "Extension" };
            colSize = new DataGridViewTextBoxColumn {DataPropertyName = "Size", Name = "Size"};
            colDateModified = new DataGridViewTextBoxColumn { DataPropertyName = "DateModified", Name = "Date Modified" };
            colDateAccessed = new DataGridViewTextBoxColumn { DataPropertyName = "DateAccessed", Name = "Date Accessed" };
            colDateCreated = new DataGridViewTextBoxColumn { DataPropertyName = "DateCreated", Name = "Date Created" };
            colPath = new DataGridViewTextBoxColumn { DataPropertyName = "Path", Name = "Path" };
            dataGridView.Columns.AddRange(colFile, colExtension, colSize, colDateModified, colDateAccessed,
                colDateCreated, colPath);
            LoadColumnWidths();
        }

        private bool DataListHasItems() {
            return dataGridView.RowCount > 0;
        }

        private string SetParentFolder() {
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return null;
            var path = folderBrowserDialog.SelectedPath;
            SetWindowTitle(path);
            return path;
        }

        private void SetWindowTitle(string title) {
            Text = title + @" - Archiver";
        }

        private void SaveColumnWidths() {
            Properties.Settings.Default.colFileWidth = dataGridView.Columns[0].Width;
            Properties.Settings.Default.colExtWidth = dataGridView.Columns[1].Width;
            Properties.Settings.Default.colSizeWidth = dataGridView.Columns[2].Width;
            Properties.Settings.Default.colDateModWidth = dataGridView.Columns[3].Width;
            Properties.Settings.Default.colDateAccWidth = dataGridView.Columns[4].Width;
            Properties.Settings.Default.colDateCreateWidth = dataGridView.Columns[5].Width;
            Properties.Settings.Default.colPathWidth = dataGridView.Columns[6].Width;
            Properties.Settings.Default.Save();
        }

        private void LoadColumnWidths() {
            dataGridView.Columns[0].Width = Properties.Settings.Default.colFileWidth;
            dataGridView.Columns[1].Width = Properties.Settings.Default.colExtWidth;
            dataGridView.Columns[2].Width = Properties.Settings.Default.colSizeWidth;
            dataGridView.Columns[3].Width = Properties.Settings.Default.colDateModWidth;
            dataGridView.Columns[4].Width = Properties.Settings.Default.colDateAccWidth;
            dataGridView.Columns[5].Width = Properties.Settings.Default.colDateCreateWidth;
            dataGridView.Columns[6].Width = Properties.Settings.Default.colPathWidth;
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
            BuildFileListFromParentFolder();
        }

        private void BuildFileListFromParentFolder() {
            var getFileListForm = new GetFileListForm(parentFolder, searchFilter);
            if (getFileListForm.ShowDialog() != DialogResult.OK || getFileListForm.fileList.Count <= 0) return;
            fileList = getFileListForm.fileList;
        }

        private void LoadItemsFromFileList() {
            dataGridView.DataSource = null;
            BuildDataGridViewColumns();
            if (fileList.Count <= 0) {
                AudioBeep();
                return;
            }
            dataGridView.DataSource = fileList;
            btnRefresh.Enabled = true;
            string fileCountText = "File count: " + fileList.Count;
            tslblFileCount.Text = fileCountText;
        }

        private static void AudioBeep() {
            System.Media.SystemSounds.Asterisk.Play();
        }

        public ArchiverMainWindow() {
            InitializeComponent();
            searchFilter = new SearchFilter();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            SetFunctionButtonStates(true);
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            if (dataGridView.RowCount == 0) {
                SetFunctionButtonStates(false);
            }
        }

        private void SetFunctionButtonStates(bool condition) {
            btnRemoveAllFiles.Enabled = condition;
            btnRemoveSelected.Enabled = condition;
            btnQuarantine.Enabled = condition;
            btnQuarantineSelected.Enabled = condition;
            btnExportList.Enabled = condition;
        }

        private void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
            SaveColumnWidths();
        }
    }
}
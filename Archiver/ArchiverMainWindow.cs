using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Archiver {
    /*  (in no particular order)
     *  
     *  TODO  1. Search by extensions
     *  TODO  2. 
     *  
     */


    public partial class ArchiverMainWindow : Form {

        private SearchFilter searchFilter;

        private List<FileData> fileList = new List<FileData>();
        private string parentFolder;
        private SortOrder sortOrder = SortOrder.Ascending;
        private const string INVALID_EXTENSION_MSG = "Invalid extensions";

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

        private void btnExport_Click(object sender, EventArgs e) {
            if (!DataListHasItems()) return;
            ExportFileList();
        }

        private void ExportFileList() {
            new ExportForm(fileList).ShowDialog();
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

        private void chkFilter_CheckedChanged(object sender, EventArgs e) {
            EnableFilterControls(chkFilter.Checked);
            if (!chkFilter.Checked) EnableExtensionFilterControls(false);
        }

        private void chkFilterByExtension_CheckedChanged(object sender, EventArgs e) {
            EnableExtensionFilterControls(chkFilterByExtension.Checked);
        }

        private void EnableExtensionFilterControls(bool condition) {
            chkFilterByExtension.Checked = condition;
            txtFilterByExtension.Enabled = condition;
            radInclude.Enabled = condition;
            radExclude.Enabled = condition;
        }

        private void txtFilterByExtension_Enter(object sender, EventArgs e) {
            if (txtFilterByExtension.Tag != null) // Tag used as an error flag
                ResetExtensionFilterError();
        }

        private void ResetExtensionFilterError() {
            txtFilterByExtension.Tag = null;
            if (txtFilterByExtension.Text == INVALID_EXTENSION_MSG)
                txtFilterByExtension.ResetText();
        }

        private void EnableFilterControls(bool condition) {
            cbxSearchStyle.Enabled = condition;
            radOlderThan.Enabled = condition;
            radNewerThan.Enabled = condition;
            dateFilterDate.Enabled = condition;
            chkFilterByExtension.Enabled = condition;
        }

        private void cbxSearchStyle_SelectedIndexChanged(object sender, EventArgs e) {
            searchFilter.Style = GetSearchStyle();
            btnRefresh.Enabled = DataListHasItems();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            var name = (string) dataGridView.SelectedRows[0].Cells["File"].Value;
            var path = (string) dataGridView.SelectedRows[0].Cells["Path"].Value;
            if (dataGridView.SelectedRows.Count == 1) {
                if (e.ClickedItem == ctxOpenFileLocation) {
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
                else if (e.ClickedItem == ctxOpenFile) {
                    var pathToFile = path + "\\" + name;
                    System.Diagnostics.Process.Start("explorer.exe", pathToFile);
                }
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
            ValidateExtensionFilter();
            searchFilter = new SearchFilter {
                FilterEnabled = chkFilter.Checked,
                Style = GetSearchStyle(),
                Period = GetSearchPeriod(),
                Date = dateFilterDate.Value,
                Option = GetSearchOption(),
                Extensions = GetExtensions(),
                ExtensionFilter = GetExtensionFilter(),
                IncludeEmptyFiles = chkIncludeEmptyFiles.Checked
            };
        }

        private void ValidateExtensionFilter() {
            var text = txtFilterByExtension.Text;
            if (string.IsNullOrEmpty(text)) return;
            var ILLEGAL_CHARS = "<>:\"/\\|?*".ToCharArray();
            var extensions = text.Replace("*", "").Replace(" ", "").Split(',');
            if (extensions.Any(ext => !ext.StartsWith(".") || ext.Count(x => x.Equals('.')) > 1 || ext.IndexOfAny(ILLEGAL_CHARS) >= 0))
                ExtensionFormatError();
        }

        private void ExtensionFormatError() {
            txtFilterByExtension.Tag = true; // Tag used as an error flag
            txtFilterByExtension.Text = INVALID_EXTENSION_MSG;
            EnableExtensionFilterControls(false);
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

        private string[] GetExtensions() {
            var text = txtFilterByExtension.Text;
            return string.IsNullOrEmpty(text) || text == INVALID_EXTENSION_MSG ? SearchFilter.DEFAULT_EXT : text.Replace("*", "").Replace(" ", "").Split(',');
        }

        private ExtensionFilter GetExtensionFilter() {
            return radInclude.Checked ? ExtensionFilter.Inclusive : ExtensionFilter.Exclusive;
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
        
    }
}
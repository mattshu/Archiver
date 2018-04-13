﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Archiver {
    /*  (in no particular order)
     *  
     *  TODO  1. MoveUp, MoveDown in Export form
     *  TODO  2. Search by extensions
     *  TODO  3. 
     *  
     */


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

        private void radOlderThan_CheckedChanged(object sender, EventArgs e) {
            searchFilter.Period = GetSearchPeriod();
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e) {
            EnableFilterControls(chkFilter.Checked);
        }

        private void chkFilterByExtension_CheckedChanged(object sender, EventArgs e) {
            txtFilterByExtension.Enabled = chkFilterByExtension.Checked;
        }

        private void EnableFilterControls(bool condition) {
            cbxSearchStyle.Enabled = condition;
            radOlderThan.Enabled = condition;
            radNewerThan.Enabled = condition;
            dateFilterDate.Enabled = condition;
            chkFilterByExtension.Enabled = condition;
            txtFilterByExtension.Enabled = condition;
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
            searchFilter = new SearchFilter {
                Style = GetSearchStyle(),
                Period = GetSearchPeriod(),
                Date = dateFilterDate.Value,
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
    }
}
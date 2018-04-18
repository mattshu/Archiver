using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Archiver {
    public partial class GetFileListForm : Form {
        private readonly string path;
        private readonly SearchFilter searchFilter;

        public GetFileListForm(string path, SearchFilter searchFilter) {
            InitializeComponent();
            if (string.IsNullOrEmpty(path)) {
                Dialogs.ErrorOK("Invalid path", "Cannot Load Files");
                Load += (s, e) => Close();
                return;
            }
            this.path = path;
            fileList = new List<FileData>();
            this.searchFilter = searchFilter;
        }

        public List<FileData> fileList { get; }

        private void GetFileListForm_Shown(object sender, EventArgs e) {
            btnCancel.Enabled = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            var diTop = new DirectoryInfo(path);
            var progress = 0;
            try {
                foreach (var fi in diTop.EnumerateFiles())
                    try {
                        if (e.Cancel) break;
                        TryGettingFile(progress++, fi);
                    }
                    catch (UnauthorizedAccessException) {
                        // Ignore unaccessible files
                    }
                if (searchFilter.Option != SearchOption.AllDirectories)
                    return;
                foreach (var di in diTop.EnumerateDirectories("*"))
                    try {
                        foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
                            try {
                                if (e.Cancel) break;
                                TryGettingFile(progress++, fi);
                            }
                            catch (UnauthorizedAccessException) {
                                // Ignore unaccessible files
                            }
                    }
                    catch (UnauthorizedAccessException) {
                        // Ignore unaccessible files
                    }
            }
            catch (Exception) {
                // Ignore unaccessible files
            }
        }

        private void TryGettingFile(int progress, FileInfo file) {
            if (!CheckSearchFilter(file)) return;
            fileList.Add(new FileData(file));
            ReportProgress(progress, file);
        }

        private bool CheckSearchFilter(FileInfo file) {
            if (!searchFilter.IncludeEmptyFiles && file.Length <= 0) return false;
            if (!searchFilter.FilterEnabled) return true;
            if (searchFilter.Extensions != SearchFilter.DEFAULT_EXT && !CheckExtensions(file)) return false;
            return CheckSearchPeriod(file);
        }

        private bool CheckExtensions(FileInfo file) {
            if (searchFilter.Extensions.Any(ext => ext == file.Extension))
                return searchFilter.ExtensionFilter == ExtensionFilter.Inclusive;
            return searchFilter.ExtensionFilter == ExtensionFilter.Exclusive;
        }

        private bool CheckSearchPeriod(FileInfo file) {
            var compare = 0;
            if (searchFilter.Style == SearchStyle.DateModified)
                compare = file.LastWriteTime.CompareTo(searchFilter.Date);
            else if (searchFilter.Style == SearchStyle.DateAccessed)
                compare = file.LastAccessTime.CompareTo(searchFilter.Date);
            else if (searchFilter.Style == SearchStyle.DateCreated)
                compare = file.CreationTime.CompareTo(searchFilter.Date);
            if (searchFilter.Period == SearchPeriod.OlderThan && compare > 0 ||
                searchFilter.Period == SearchPeriod.NewerThan && compare < 0) return false;
            if (searchFilter.Period == SearchPeriod.NewerThan)
                compare *= -1;
            return compare < 0;
        }

        private void ReportProgress(int progress, FileInfo file) {
            // Send updates every 100 files
            if (progress % 100 == 0) backgroundWorker.ReportProgress(progress, file.Name);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var fname = (string) e.UserState;
            var statusMsg = "Found: " + fname;
            UpdateProgress(e.ProgressPercentage, statusMsg);
        }

        private void UpdateProgress(int foundSoFar, string statusMsg) {
            lblFilesFound.Text = foundSoFar + @" files found so far";
            SetStatus(statusMsg);
        }

        private void SetStatus(string msg) {
            lblStatus.Text = msg;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DialogResult = fileList.Count > 0 ? DialogResult.OK : DialogResult.None;
            Close();
        }
    }
}
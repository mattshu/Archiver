using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Archiver {
    public partial class GetFileListForm : Form {
        public List<FileData> fileList { get; }
        private readonly string path;
        private readonly SearchFilter searchFilter;
        private int fileCount;

        private class ProgressData {
            public int Counter;
            public string Filename;
        }

        public GetFileListForm(string path, SearchFilter searchFilter) {
            InitializeComponent();
            if (string.IsNullOrEmpty(path)) {
                Error.Show("Invalid path", "Cannot Load Files");
                Load += (s, e) => Close();
                return;
            }
            this.path = path;
            fileList = new List<FileData>();
            this.searchFilter = searchFilter;
        }

        private void GetFileListForm_Shown(object sender, EventArgs e) {
            Refresh();
            fileCount = GetFileCount();
            if (fileCount <= 0) {
                Close();
                return;
            }
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
                        if (TryGettingFile(fi, progress++)) continue;
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
                                if (TryGettingFile(fi, progress++)) continue;
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

        private bool TryGettingFile(FileInfo fi, int progress) {
            if (!CheckSearchFilter(fi)) return false;
            fileList.Add(new FileData(fi));
            ReportProgress(fi, progress);
            return true;
        }

        private void ReportProgress(FileInfo fi, int progress) {
            // Send updates every 100 files (every 10 if < 100)
            if (progress < 100 && progress % 10 == 0 || progress % 100 == 0) {
                var prog = progress / (double) fileCount;
                var perc = Convert.ToInt32(prog * 100);
                var progData = new ProgressData {Counter = progress, Filename = fi.Name};
                backgroundWorker.ReportProgress(perc, progData);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var progData = (ProgressData) e.UserState;
            var statusMsg = "Found: " + progData.Filename;
            updateProgress(e.ProgressPercentage, statusMsg);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DialogResult = fileList.Count > 0 ? DialogResult.OK : DialogResult.None;
            Close();
        }

        private bool CheckSearchFilter(FileSystemInfo file) {
            if (!searchFilter.Enabled) return true;
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

        private int GetFileCount() {
            /*var dirInfo = new DirectoryInfo(path);
            return dirInfo.EnumerateDirectories().AsParallel()
                .SelectMany(di => di.EnumerateFiles("*", SearchOption.AllDirectories)).Count();*/
            var count = 0;
            var diTop = new DirectoryInfo(path);
            try {
                foreach (var fi in diTop.EnumerateFiles())
                    try {
                        count++;
                    }
                    catch (UnauthorizedAccessException) { }
                if (searchFilter.Option != SearchOption.AllDirectories)
                    return count;
                foreach (var di in diTop.EnumerateDirectories("*"))
                    try {
                        foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
                            try {
                                count++;
                            }
                            catch (UnauthorizedAccessException) { }
                    }
                    catch (UnauthorizedAccessException) { }
            }
            catch (Exception) {
                ;
            }
            return count;
        }

        private void updateProgress(int percentage, string statusMsg) {
            progressBar.Value = percentage;
            lblProgressPercentage.Text = percentage + @"%";
            status(statusMsg);
        }

        private void status(string msg) {
            lblStatus.Text = msg;
        }
    }
}
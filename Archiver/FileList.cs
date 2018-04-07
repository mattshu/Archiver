﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archiver {
    class FileList {

        public List<FileData> fileList { get; }
        private readonly string path;
        private readonly SearchFilter searchFilter;
        private int fileCount;
        private readonly BackgroundWorker backgroundWorker;

        private class ProgressData {
            public int Counter;
            public string Filename;
        }

        public FileList(string path, SearchFilter searchFilter) {
            this.path = path;
            this.searchFilter = searchFilter;
            fileList = new List<FileData>();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        public void GetFileList() { 
            fileCount = GetFileCount();
            if (fileCount <= 0) {
                // TODO No files found
                return;
            }
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            var diTop = new DirectoryInfo(path);
            int progress = 0;
            try {
                foreach (var fi in diTop.EnumerateFiles()) {
                    try {
                        if (e.Cancel) break;
                        if (TryGettingFile(fi, progress++)) continue;
                    }
                    catch (UnauthorizedAccessException) {
                        // Ignore unaccessible files
                    }
                }
                if (searchOption != SearchOption.AllDirectories) return;
                foreach (var di in diTop.EnumerateDirectories("*")) {
                    try {
                        foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories)) {
                            try {
                                if (e.Cancel) break;
                                if (TryGettingFile(fi, progress++)) continue;
                            }
                            catch (UnauthorizedAccessException) {
                                // Ignore unaccessible files
                            }
                        }
                    }
                    catch (UnauthorizedAccessException) {
                        // Ignore unaccessible files
                    }
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
                var prog = progress / (double)fileCount;
                var perc = Convert.ToInt32(prog * 100);
                var progData = new ProgressData { Counter = progress, Filename = fi.Name };
                backgroundWorker.ReportProgress(perc, progData);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var progData = (ProgressData)e.UserState;
            updateProgress(e.ProgressPercentage, progData.Counter, progData.Filename);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DialogResult = fileList.Count > 0 ? DialogResult.OK : DialogResult.None;
            Close();
        }

        private bool CheckSearchFilter(FileSystemInfo file) {
            if (!enableFilter) return true;
            var compare = 0;
            if (searchStyle == SearchStyle.DateModified)
                compare = file.LastWriteTime.CompareTo(searchDate);
            else if (searchStyle == SearchStyle.DateAccessed)
                compare = file.LastAccessTime.CompareTo(searchDate);
            else if (searchStyle == SearchStyle.DateCreated)
                compare = file.CreationTime.CompareTo(searchDate);
            if (searchPeriod == SearchPeriod.OlderThan && compare > 0 ||
                    searchPeriod == SearchPeriod.NewerThan && compare < 0) return false;
            if (searchPeriod == SearchPeriod.NewerThan)
                compare *= -1;
            return compare < 0;
        }

        private int GetFileCount() {
            int count = 0;
            var diTop = new DirectoryInfo(path);
            try {
                foreach (var fi in diTop.EnumerateFiles()) {
                    try {
                        count++;
                    }
                    catch (UnauthorizedAccessException) {
                    }
                }
                foreach (var di in diTop.EnumerateDirectories("*")) {
                    try {
                        foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories)) {
                            try {
                                count++;
                            }
                            catch (UnauthorizedAccessException) {
                                continue;
                            }
                        }
                    }
                    catch (UnauthorizedAccessException) {
                        continue;
                    }
                }
            }
            catch (Exception) {
                ;
            }
            return count;
        }

        private void updateProgress(int percentage, int counter, string filename) {
            progressBar.Value = percentage;
            lblProgressPercentage.Text = percentage + @"%";
            lblFileIteration.Text = @"Loading " + counter + @"/" + fileCount + @" files";
            status("Found: " + filename);
        }

        private void status(string msg) {
            lblStatus.Text = msg;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archiver {
    public partial class GetFileListForm : Form {

        private string path;
        private int fileCount;
        private SearchConditions searchConditions;
        public List<FileData> fileList { get; }

        private class ProgressData {
            public int Counter;
            public string Filename;
        }

        public GetFileListForm(string path, SearchConditions searchConditions) {
            InitializeComponent();
            if (string.IsNullOrEmpty(path)) {
                Error.Show("Invalid path", "Cannot Load Files");
                Load += (s, e) => Close();
                return;
            }
            this.path = path;
            this.searchConditions = searchConditions;
            fileList = new List<FileData>();
        }

        private void status(string msg) {
            lblStatus.Text = msg;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            var dir = new DirectoryInfo(path);
            int i = 0;
            foreach (var file in dir.EnumerateFiles("*", searchConditions.Option)) {
                if (e.Cancel) break;
                fileList.Add(new FileData(file));
                i++;
                double prog = (double)i / (double)fileCount;
                int perc = Convert.ToInt32(prog * 100);
                var progData = new ProgressData { Counter = i, Filename = file.Name };
                // Send updates every 100 files (every 10 if < 100)
                if (i < 100 && i % 10 == 0 || i % 100 == 0) backgroundWorker.ReportProgress(perc, progData);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var progData = (ProgressData)e.UserState;
            updateProgress(e.ProgressPercentage, progData.Counter, progData.Filename);
        }

        private void updateProgress(int percentage, int counter, string filename) {
            progressBar.Value = percentage;
            lblProgressPercentage.Text = percentage + @"%";
            lblFileIteration.Text = "Loading " + counter + "/" + fileCount + " files";
            status("Found: " + filename);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DialogResult = fileList.Count > 0 ? DialogResult.OK : DialogResult.None;
            Close();
        }

        private void GetFileListForm_Shown(object sender, EventArgs e) {
            Refresh();
            fileCount = (int)Invoke((Func<int>)(() => Directory.EnumerateFiles(path, "*", searchConditions.Option).Count()));
            btnCancel.Enabled = true;
            backgroundWorker.RunWorkerAsync();
        }
    }
}

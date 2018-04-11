using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Archiver {
    public partial class ExportForm : Form {
        private readonly List<FileData> fileList;

        public ExportForm(List<FileData> fileList) {
            InitializeComponent();
            if (fileList.Count <= 0) {
                DialogResult = DialogResult.Abort;
                Load += (s, e) => Close();
                return;
            }
            this.fileList = fileList;
        }

        private void ExportForm_Shown(object sender, EventArgs e) {
            CheckAllItems();
            PopulateFormatList();
            cbxFormat.SelectedIndex = 0;
        }

        private void CheckAllItems() {
            for (var i = 0; i < chklistExclusions.Items.Count; i++)
                chklistExclusions.SetItemChecked(i, true);
        }

        private void PopulateFormatList() {
            foreach (var format in Enum.GetValues(typeof(ExportFormat)))
                cbxFormat.Items.Add((ExportFormat) format);
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {
            // TODO
        }

        private void btnMoveDown_Click(object sender, EventArgs e) {
            // TODO
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            SetSavePath();
        }

        private void txtPath_MouseClick(object sender, MouseEventArgs e) {
            SetSavePath();
        }

        private void SetSavePath() {
            var extension = (ExportFormat) cbxFormat.SelectedIndex;
            saveFileDialog.DefaultExt = "." + extension;
            saveFileDialog.Filter = extension + @" format|." + extension;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            txtPath.Text = saveFileDialog.FileName;
        }

        private void btnExport_Click(object sender, EventArgs e) {
            if (txtPath.Text.Length <= 0)
                Dialogs.Message(@"Invalid path name");
            else if (chklistExclusions.CheckedItems.Count == 0)
                Dialogs.Message(@"No fields selected");
            else
                Export();
        }

        private void Export() {
            try {
                var path = txtPath.Text;
                var format = (ExportFormat) cbxFormat.SelectedIndex;
                var columns = GetColumns();
                var exporter = new Exporter(fileList, path, format, columns);
                exporter.Start();
                MessageBox.Show(@"Export saved to: " + path, @"Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e) {
                DialogResult = DialogResult.Abort;
                Debug.WriteLine(e.StackTrace);
                Dialogs.ErrorOK(@"Unable to export file:\n " + e.Message, @"Export Error");
            }
            finally {
                Close();
            }
        }

        private List<ColumnType> GetColumns() {
            var columns = new List<ColumnType>();
            for (var i = 0; i < chklistExclusions.Items.Count; i++)
                if (chklistExclusions.GetItemChecked(i))
                    columns.Add((ColumnType) i);
            return columns;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
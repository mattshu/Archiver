using System;
using System.Collections.Generic;
using System.Linq;
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
                cbxFormat.Items.Add((ExportFormat)format);
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {
            MoveSelectedListItem(-1);
        }

        private void btnMoveDown_Click(object sender, EventArgs e) {
            MoveSelectedListItem(1);
        }

        private void MoveSelectedListItem(int direction) {
            if (direction < -1 || direction > 1) return;
            var index = chklistExclusions.SelectedIndex;
            if (index + direction < 0 || index + direction >= chklistExclusions.Items.Count) return;
            var itemChecked = chklistExclusions.GetItemChecked(index);
            var itemToMove = chklistExclusions.Items[index];
            chklistExclusions.Items.RemoveAt(index);
            chklistExclusions.Items.Insert(index + direction, itemToMove);
            chklistExclusions.SetItemChecked(index + direction, itemChecked);
            chklistExclusions.SelectedIndex = index + direction;
        }

        private void btnExport_Click(object sender, EventArgs e) {
            if (chklistExclusions.CheckedItems.Count == 0)
                Dialogs.Message(@"No fields selected");
            else
                Export();
        }

        private void Export() {
            try {
                var format = (ExportFormat) cbxFormat.SelectedIndex;
                var columns = GetColumns();
                var exporter = new Exporter(fileList, format, columns);
                exporter.Start();
            }
            catch (Exception e) {
                DialogResult = DialogResult.Abort;
                Dialogs.ErrorOK("Unable to export file:\n " + e.Message, @"Export Error");
            }
            finally {
                Close();
            }
        }

        private List<ColumnType> GetColumns() {
            var columns = new List<ColumnType>();
            for (var i = 0; i < chklistExclusions.Items.Count; i++)
                if (chklistExclusions.GetItemChecked(i))
                    columns.Add((ColumnType)Enum.Parse(typeof(ColumnType), ((string)chklistExclusions.Items[i]).Replace(" ", "")));
            return columns;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
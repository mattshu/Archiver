using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Archiver {
    internal class Exporter {
        private readonly List<FileData> fileList;
        private readonly ExportFormat format;
        private readonly List<ColumnType> columns;

        public Exporter(List<FileData> fileList, ExportFormat format, List<ColumnType> columns) {
            this.fileList = fileList;
            this.format = format;
            this.columns = columns;
        }

        public void Start() {
            if (fileList == null || fileList.Count <= 0) throw new Exception(@"File list is empty");
            switch (format) {
                case ExportFormat.CSV:
                    ExportAsCSV();
                    break;
                case ExportFormat.XML:
                    ExportAsXML();
                    break;
                case ExportFormat.JSON:
                    ExportAsJSON();
                    break;
                default:
                    throw new Exception(@"Invalid export format");
            }
        }

        private void ExportAsCSV() {
            var stringBuilder = new StringBuilder();
            foreach (var file in fileList)
                stringBuilder.AppendLine(ExportConverter.ToCSV(file, columns));
            SaveToFile(stringBuilder.ToString());
        }

        private void ExportAsXML() {
            var stringBuilder = new StringBuilder();
            foreach (var file in fileList)
                stringBuilder.Append(ExportConverter.ToXML(file, columns));
            SaveToFile(stringBuilder.ToString());
        }

        private void ExportAsJSON() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(@"[");
            foreach (var file in fileList)
                stringBuilder.Append(ExportConverter.ToJSON(file, columns));
            stringBuilder.AppendLine(@"]");
            SaveToFile(stringBuilder.ToString().TrimEnd(','));
        }

        private void SaveToFile(string data) {
            try {
                var extension = format.ToString();
                var saveFileDialog = new SaveFileDialog {
                    DefaultExt = "." + extension.ToLower(),
                    Filter = extension + @" format|." + extension.ToLower()
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                File.WriteAllText(saveFileDialog.FileName, data);
                Dialogs.Info("Export written to:\n " + saveFileDialog.FileName);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
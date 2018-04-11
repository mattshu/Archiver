using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archiver {
    internal class Exporter {
        private readonly List<FileData> fileList;
        private readonly string path;
        private readonly ExportFormat format;
        private readonly List<ColumnType> columns;

        public Exporter(List<FileData> fileList, string path, ExportFormat format, List<ColumnType> columns) {
            this.fileList = fileList;
            this.path = path;
            this.format = format;
            this.columns = columns;
        }

        public void Start() {
            if (fileList == null) return;
            switch (format) {
                case ExportFormat.CSV:
                    ExportAsCSV();
                    break;
                case ExportFormat.JSON:
                    ExportAsJSON();
                    break;
                case ExportFormat.XML:
                    ExportAsXML();
                    break;
                default:
                    throw new Exception(@"Invalid export format");
            }
        }

        private void ExportAsCSV() {
            var stringBuilder = new StringBuilder();
            foreach (var file in fileList) {
                stringBuilder.Append(file.ToCSV(columns));
                stringBuilder.Append(Environment.NewLine);
            }
            if (stringBuilder.Length <= 0) throw new Exception(@"File list is empty");
            SaveToFile(stringBuilder);
        }

        private void ExportAsJSON() {
            throw new NotImplementedException();
        }

        private void ExportAsXML() {
            throw new NotImplementedException();
        }

        private void SaveToFile(StringBuilder stringBuilder) {
            try {
                File.WriteAllText(path, stringBuilder.ToString());
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}

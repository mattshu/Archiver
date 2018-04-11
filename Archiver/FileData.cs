using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archiver {
    public class FileData {
        public string Name { get; }
        public string Extension { get; }
        public string Size { get; }
        public DateTime DateModified { get; }
        public DateTime DateAccessed { get; }
        public DateTime DateCreated { get; }
        public string Path { get; }

        public FileData(string filePath) {
            var fileInfo = new FileInfo(filePath);
            Name = fileInfo.Name;
            Extension = fileInfo.Extension;
            Size = BytesToString(fileInfo.Length);
            DateModified = fileInfo.LastWriteTime;
            DateAccessed = fileInfo.LastAccessTime;
            DateCreated = fileInfo.CreationTime;
            Path = fileInfo.DirectoryName;
        }

        public FileData(FileInfo fileInfo) : this(fileInfo.FullName) { }

        public string GetFilePath() {
            return Path + @"\\" + Name;
        }

        public string ToCSV(List<ColumnType> columns) {
            var stringBuilder = new StringBuilder();
            foreach (var col in columns) {
                switch (col) {
                    case ColumnType.Name:
                        stringBuilder.Append(Name + ",");
                        break;
                    case ColumnType.Extension:
                        stringBuilder.Append(Extension + ",");
                        break;
                    case ColumnType.Size:
                        stringBuilder.Append(Size + ",");
                        break;
                    case ColumnType.DateModified:
                        stringBuilder.Append(DateModified + ",");
                        break;
                    case ColumnType.DateAccessed:
                        stringBuilder.Append(DateAccessed + ",");
                        break;
                    case ColumnType.DateCreated:
                        stringBuilder.Append(DateCreated + ",");
                        break;
                    case ColumnType.Path:
                        stringBuilder.Append(Path + ",");
                        break;
                    default:
                        throw new Exception(@"Invalid column - ToCSV()");
                }
            }
            if (stringBuilder[stringBuilder.Length - 1] == ',') stringBuilder.Length--; // Trim last comma
            return stringBuilder.ToString();
        }

        private string BytesToString(long byteCount) {
            string[] suf = {"B", "KB", "MB", "GB", "TB", "PB", "EB"}; //Longs run out around EB
            if (byteCount == 0)
                return @"0";
            var bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            if (place < 1) return @"1 KB";
            var num = Math.Round(bytes / Math.Pow(1024, place));
            return Math.Sign(byteCount) * num + " " + suf[place];
        }

        /*public string GetStringFromColumn(ColumnType col) {
            switch (col) {
                case ColumnType.Name:
                    
            }
            return "";
        }*/

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Archiver {
        public class FileData {
            public DateTime DateAccessed { get; }
            public DateTime DateCreated { get; }
            public DateTime DateModified { get; }
            public string Extension { get; }
            public string Name { get; }
            public string Path { get; }
            public string Size { get; }

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

        public FileData(FileInfo fileInfo) : this(fileInfo.FullName) {}

        public string GetFilePath() {
            return Path + "\\" + Name;
        }
        private string BytesToString(long byteCount) {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0";
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            if (place < 1) return "1 KB";
            double num = Math.Round(bytes / Math.Pow(1024, place));
            return (Math.Sign(byteCount) * num) + " " + suf[place];
        }
    }
}
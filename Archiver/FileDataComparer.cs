using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Archiver {
    internal class FileDataComparer : IComparer<FileData> {
        public ColumnType Column { get; set; }
        public SortOrder Order { get; set; }

        public FileDataComparer(ColumnType column, SortOrder order) {
            Column = column;
            Order = order;
        }

        public int Compare(FileData itemX, FileData itemY) {
            if (itemX == null && itemY == null)
                return 0;
            if (itemX == null)
                return -1;
            if (itemY == null)
                return 1;
            if (itemX == itemY)
                return 0;

            int value;
            
            switch (Column) {
                case ColumnType.File:
                    value = string.CompareOrdinal(itemX.Name, itemY.Name);
                    break;
                case ColumnType.Extension:
                    value = string.CompareOrdinal(itemX.Extension, itemY.Extension);
                    break;
                case ColumnType.Size:
                    value = CompareAsSize(itemX, itemY);
                    break;
                case ColumnType.DateModified:
                    value = DateTime.Compare(itemX.DateModified, itemY.DateModified);
                    break;
                case ColumnType.DateAccessed:
                    value = DateTime.Compare(itemX.DateAccessed, itemY.DateAccessed);
                    break;
                case ColumnType.DateCreated:
                    value = DateTime.Compare(itemX.DateCreated, itemY.DateCreated);
                    break;
                case ColumnType.Path:
                    value = decimal.Compare(itemX.Path.TakeWhile(c => c == '\\').Count(), itemY.Path.TakeWhile(c => c == '\\').Count());
                    break;
                default:
                    return 0;
            }

            if (Order == SortOrder.Descending) value *= -1;
            //Debug.WriteLine($"Sort result for {itemX.Name} -> {itemY.Name} ({value})");
            return value;
        }

        public int CompareAsSize(FileData itemX, FileData itemY) {
            decimal itemXSize = GetSize(itemX);
            decimal itemYSize = GetSize(itemY);
            return decimal.Compare(itemXSize, itemYSize);
        }
        private static decimal GetSize(FileData data) {
            string[] splitText = data.Size.Split();
            if (splitText.Length <= 1) return -1;
            decimal size = decimal.Parse(splitText[0]);
            string sizeSuffix = splitText[1];
            switch (sizeSuffix) {
                case "MB":
                    size *= 1024;
                    break;
                case "GB":
                    size *= 1024 * 1024;
                    break;
                case "TB":
                    size *= 1024 * 1024 * 1024;
                    break;
                case "PB": // TODO: Futureproof
                case "EB": // ^
                default:
                    break;
            }
            return size;
        }
    }
}
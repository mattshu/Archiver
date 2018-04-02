using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Archiver
{
    public class ListViewItemComparer : IComparer {
        public ColumnType Column { get; set; }
        public SortOrder Order { get; set; }

        public ListViewItemComparer(ColumnType column, SortOrder order)
        {
            Column = column;
            Order = order;
        }
        public ListViewItemComparer(int column, SortOrder order) {
            Column = (ColumnType) column;
            Order = order;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = x as ListViewItem;
            ListViewItem itemY = y as ListViewItem;
            
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
                case ColumnType.Extension:
                    value = CompareAsText(itemX, itemY);
                    break;
                case ColumnType.Size:
                    value = CompareAsSize(itemX, itemY);
                    break;
                case ColumnType.DateModified:
                case ColumnType.DateAccessed:
                case ColumnType.DateCreated:
                    value = CompareAsDate(itemX, itemY);
                    break;
                case ColumnType.Path:
                    value = CompareAsPath(itemX, itemY);
                    break;
                default:
                    return 0;
            }

            if (Order == SortOrder.Descending) value *= -1;
            return value;
        }

        private int CompareAsText(ListViewItem itemX, ListViewItem itemY) {
            string itemXText = GetText(itemX);
            string itemYText = GetText(itemY);
            return string.CompareOrdinal(itemXText, itemYText);
        }

        private string GetText(ListViewItem lvi) {
            return lvi.SubItems[(int)Column].Text;
        }

        private int CompareAsSize(ListViewItem itemX, ListViewItem itemY) {
            decimal itemXValue = GetSize(itemX);
            decimal itemYValue = GetSize(itemY);
            return decimal.Compare(itemXValue, itemYValue);
        }

        private decimal GetSize(ListViewItem lvi) {
            string[] splitText = lvi.SubItems[(int) Column].Text.Split();
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

        private int CompareAsDate(ListViewItem itemX, ListViewItem itemY) {
            if (!DateTime.TryParse(itemX.SubItems[(int)Column].Text, out DateTime itemXDate))
                itemXDate = DateTime.MinValue;
            if (!DateTime.TryParse(itemY.SubItems[(int)Column].Text, out DateTime itemYDate))
                itemYDate = DateTime.MinValue;
            return DateTime.Compare(itemXDate, itemYDate);
        }

        private int CompareAsPath(ListViewItem itemX, ListViewItem itemY) {
            string itemXPath = GetText(itemX);
            string itemYPath = GetText(itemY);
            return decimal.Compare(itemXPath.TakeWhile(c => c == '\\').Count(), itemYPath.TakeWhile(c => c == '\\').Count());

        }

    }
}
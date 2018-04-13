using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archiver {
    public static class ExportConverter {

        public static string ToCSV(FileData fileData, List<ColumnType> columns) {
            var stringBuilder = new StringBuilder();
            foreach (var col in columns) 
                stringBuilder.Append(GetPropertyByColumn(fileData, col) + ",");
            return stringBuilder.ToString().TrimEnd(',');
        }

        public static string ToXML(FileData fileData, List<ColumnType> columns) {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<FileData>");
            foreach (var col in columns) {
                var openTag = "<" + col + ">";
                var data = GetPropertyByColumn(fileData, col);
                var closeTag = "</" + col + ">";
                stringBuilder.AppendLine("\t" + openTag + data + closeTag);
            }
            stringBuilder.AppendLine("</FileData>");
            return stringBuilder.ToString();
        }

        public static string ToJSON(FileData fileData, List<ColumnType> columns) {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t{");
            foreach (var col in columns) {
                var line = "\t\t\"" + col + "\": " + '\"' + GetPropertyByColumn(fileData, col) + '\"';
                stringBuilder.Append(line);
                if (!col.Equals(columns.Last()))
                    stringBuilder.Append(",");
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder + "\t}," + Environment.NewLine;
        }

        private static object GetPropertyByColumn(FileData fileData, ColumnType col) {
            var property = fileData.GetType().GetProperty(col.ToString());
            if (property == null) return null;
            var value = property.GetValue(fileData, null);
            return col == ColumnType.Path ? ((string)value).Replace("\\", "\\\\") : value;
        }
    }
}

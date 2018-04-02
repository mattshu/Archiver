using System;
using System.IO;

namespace Archiver {
    public class SearchConditions {
        public SearchStyle Style { get; set; } = SearchStyle.ForFilesOlderThan;
        public SearchOption Option { get; set; } = SearchOption.AllDirectories;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
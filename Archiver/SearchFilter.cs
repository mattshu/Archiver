using System;
using System.IO;

namespace Archiver {
    public class SearchFilter {
        public SearchStyle Style { get; set; } = SearchStyle.DateModified;
        public SearchPeriod Period { get; set; } = SearchPeriod.OlderThan;
        public DateTime Date { get; set; } = DateTime.Now;
        public SearchOption Option { get; set; } = SearchOption.AllDirectories;
        public bool Enabled { get; set; } = false;
    }
}
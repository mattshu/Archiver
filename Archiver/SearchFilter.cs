using System;
using System.IO;

namespace Archiver {
    public class SearchFilter {
        public static readonly string DEFAULT_EXT = "*.*";
        public SearchStyle Style { get; set; } = SearchStyle.DateModified;
        public SearchPeriod Period { get; set; } = SearchPeriod.OlderThan;
        public DateTime Date { get; set; } = DateTime.Now;
        public SearchOption Option { get; set; } = SearchOption.AllDirectories;
        public string Extensions { get; set; } = DEFAULT_EXT;
        public bool Enabled { get; set; } = false;
    }
}
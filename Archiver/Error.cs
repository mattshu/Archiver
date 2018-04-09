using System.Windows.Forms;

namespace Archiver {
    internal static class Error {
        public static void Show(string msg, string title = "Error") {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
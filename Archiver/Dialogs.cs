using System.Windows.Forms;

namespace Archiver {
    public static class Dialogs {

        public static DialogResult YesNo(string message, string title = "Confirm") {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static void ErrorOK(string message, string title = "Error") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void Message(string message, string title = "Archiver") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void Info(string message, string title = "Information") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

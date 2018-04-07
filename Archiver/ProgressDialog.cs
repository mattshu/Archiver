using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Archiver {
    public partial class ProgressDialog : Form {

        private int max;

        public ProgressDialog(string statusText) {
            InitializeComponent();
            lblStatus.Text = statusText;
        }

        private void updateProgress(int percentage, int counter, string statusMsg) {
            progressBar.Value = percentage;
            lblProgressPercentage.Text = percentage + @"%";
            lblIteration.Text = @"Loading " + counter + @"/" + max + @" files";
            status(statusMsg);
        }

        private void status(string msg) {
            lblStatus.Text = msg;
        }

    }
}
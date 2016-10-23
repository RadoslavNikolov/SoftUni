using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Bases_Asynchronous_Pattern_Example.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            btnAsync.Enabled = false;

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Marquee;

            htmlClient1.DownloadHtmlAsync(new Uri("http://www.microsoft.com"));
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            btnAsync.Enabled = false;

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Marquee;

            var html = htmlClient1.DownloadHtml(new Uri("http://www.microsoft.com"));

            btnSync.Enabled = true;
            btnAsync.Enabled = true;

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void htmlClient1_DownloadHtmlCompleted(object sender, Web.DownloadHtmlComletedEventArgs e)
        {
            var html = e.Html;

            btnSync.Enabled = true;
            btnAsync.Enabled = true;

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }
    }
}

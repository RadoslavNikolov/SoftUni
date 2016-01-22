using System;
using System.Windows.Forms;

namespace DirtyTracker
{
    using System.Net.NetworkInformation;
    using System.Threading;

    public partial class MainForm : Form
    {
        private DirtyTracker dirtyTracker;
        public MainForm()
        {
            this.InitializeComponent();
            //this.FormClosing += this.MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.dirtyTracker = new DirtyTracker(this);
            this.dirtyTracker.SetAsCllean();
            Helpers.RemoteAccess.GetWmiStats(this.textBox2);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.ExitApp();
        }

        private void ExitApp()
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dirtyTracker.IsDirty)
            {
                DialogResult result =
                    (MessageBox.Show("Would you like to save changes ",
                        "Save Changes",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question));

                switch (result)
                {
                    case DialogResult.Yes:
                        // save the document
                        //SaveMyDocument();
                        break;

                    case DialogResult.No:
                        this.ExitApp();
                        break;

                    case DialogResult.Cancel:
                        // cancel the close
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void pingButton_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            var host = this.textBox1.Text;
            var responce = PingHost(host);

            this.textBox2.AppendText(string.Format("Pinging {0} [{1}] with 32 bytes of data:\n", host, responce!=null ? responce.Address.ToString() : ""));

            for (int i = 0; i < 3; i++)
            {
                if (responce != null)
                {
                    this.textBox2.AppendText(string.Format("Reply from {0}:  bytes=32  time{1} TTL={2}\n", responce.Address, responce.RoundtripTime <= 1 ? "<=1ms" : "=" + responce.RoundtripTime + "ms", responce.Options.Ttl));
                }
                else
                {
                    this.textBox2.AppendText(string.Format("Host: {0} unreachable\n", host));
                }

                Thread.Sleep(1000);
                responce = PingHost(host);
            }

            this.textBox2.AppendText("End\n");
        }

        public static PingReply PingHost(string nameOrAddess)
        {
            PingReply reply = null;
            Ping pinger = new Ping();

            try
            {
                reply = pinger.Send(nameOrAddess);
            }
            catch (PingException)
            {
                
            }
            catch (Exception)
            {
                
            }

            return reply;
        }
    }
}

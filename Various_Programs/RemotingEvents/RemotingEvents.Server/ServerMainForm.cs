using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemotingEvents.Server
{
    public partial class frm_Main : Form
    {
        RemotingServer server;
        private delegate void SetBoxText(string msg);

        public frm_Main()
        {
            this.InitializeComponent();
        }

        private void bttn_StartServer_Click(object sender, EventArgs e)
        {
            this.server = new RemotingServer();
            this.server.StartServer(15000);
            this.server.MessageArrived += this.Server_MessageArrived;
            this.SetTextBox("Server Started");
        }

        void Server_MessageArrived(string msg)
        {
            this.SetTextBox(msg);
        }

        private void bttn_StopServer_Click(object sender, EventArgs e)
        {
            this.server.StopServer();
            this.server = null;
            this.SetTextBox("Server Stopped");
        }

        private void SetTextBox(string msg)
        {
            if (this.tbx_Messages.InvokeRequired)
            {
                this.BeginInvoke(new SetBoxText(this.SetTextBox), new object[] { msg });
            }
            else
                this.tbx_Messages.AppendText(msg + "\r\n");
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemotingEvents.Common;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting;

namespace RemotingEvents.Client
{
    public partial class ClientMainForm : Form
    {
        private IServerObject remoteServer;
        private EventProxy eventProxy;
        private TcpChannel tcpChannel;
        private BinaryClientFormatterSinkProvider clientProv;
        private BinaryServerFormatterSinkProvider serverProv;
        private const string ServerUri = "tcp://127.0.0.1:15000/serverExample"; //Replace with your IP
        private bool connected = false;

        private delegate void SetBoxText(string msg);

        public ClientMainForm()
        {
            this.InitializeComponent();

            this.Init();
        }

        private void Init()
        {
            this.clientProv = new BinaryClientFormatterSinkProvider();
            this.serverProv = new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            };

            this.eventProxy = new EventProxy();
            this.eventProxy.MessageArrived += this.EventProxy_MessageArrived;

            var props = new Hashtable
            {
                ["name"] = "remotingClient",
                ["port"] = 0
            };
            //First available port

            this.tcpChannel = new TcpChannel(props, this.clientProv, this.serverProv);
            ChannelServices.RegisterChannel(this.tcpChannel, false);

            RemotingConfiguration.RegisterWellKnownClientType(new WellKnownClientTypeEntry(typeof (IServerObject), ServerUri));
        }

        private void EventProxy_MessageArrived(string msg)
        {
            this.SetTextBox(msg);
        }

        private void bttn_Connect_Click(object sender, EventArgs e)
        {
            if (this.connected)
            {
                return;
            }

            try
            {
                this.remoteServer = (IServerObject)Activator.GetObject(typeof(IServerObject), ServerUri);
                this.remoteServer.PublishMessage("Client Connected");
            
                //Attach the events
                this.remoteServer.MessageArrived += new MessageArrivedEvent(this.eventProxy.LocallyHandleMessageArrived);
                this.connected = true;
            }
            catch (Exception ex)
            {
                this.connected = false;
                this.SetTextBox("Could not connect: " + ex.Message);
            }
        }

        private void bttn_Disconnect_Click(object sender, EventArgs e)
        {
            if (!this.connected)
            {
                return;
            }

            //First remove the event
            this.remoteServer.MessageArrived -= this.eventProxy.LocallyHandleMessageArrived;

            //Now we can close it out
            ChannelServices.UnregisterChannel(this.tcpChannel);
        }

        private void bttn_Send_Click(object sender, EventArgs e)
        {
            if (!this.connected)
            {
                return;
            }

            this.remoteServer.PublishMessage(this.tbx_Input.Text);
            this.tbx_Input.Text = string.Empty;
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

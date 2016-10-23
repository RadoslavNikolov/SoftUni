using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RemotingEvents.Common;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Remoting.Channels;

namespace RemotingEvents.Server
{
    public class RemotingServer : MarshalByRefObject, IServerObject
    {
        private TcpServerChannel serverChannel;
        private int tcpPort;
        private ObjRef internalRef;
        private bool serverActive = false;
        private const string ServerUri = "serverExample";


        public event MessageArrivedEvent MessageArrived;

        public void PublishMessage(string msg)
        {
            this.SafeInvokeMessageArrived(msg);
        }

        public void StartServer(int port)
        {
            if (this.serverActive)
            {
                return;
            }

            var props = new Hashtable
            {
                ["port"] = port,
                ["name"] = ServerUri
            };

            //Set up for remoting events properly
            var serverProv = new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            };

            this.serverChannel = new TcpServerChannel(props, serverProv);

            try
            {
                ChannelServices.RegisterChannel(this.serverChannel, false);
                this.internalRef = RemotingServices.Marshal(this, props["name"].ToString());
                this.serverActive = true;
            }
            catch (RemotingException re)
            {
                //Could not start the server because of a remoting exception
            }
            catch (Exception ex)
            {
                //Could not start the server because of some other exception
            }
        }

        public void StopServer()
        {
            if (!this.serverActive)
            {
                return;
            }

            RemotingServices.Unmarshal(this.internalRef);

            try
            {
                ChannelServices.UnregisterChannel(this.serverChannel);
            }
            catch (Exception ex)
            {

            }
        }

        private void SafeInvokeMessageArrived(string msg)
        {
            if (!this.serverActive)
            {
                return;
            }

            if (this.MessageArrived == null)
            {
                return;         //No Listeners
            }

            MessageArrivedEvent listener = null;
            var dels = this.MessageArrived.GetInvocationList();

            foreach (var del in dels)
            {
                try
                {
                    listener = (MessageArrivedEvent)del;
                    listener.Invoke(msg);
                }
                catch (Exception ex)
                {
                    //Could not reach the destination, so remove it
                    //from the list
                    this.MessageArrived -= listener;
                }
            }
        }
    }
}

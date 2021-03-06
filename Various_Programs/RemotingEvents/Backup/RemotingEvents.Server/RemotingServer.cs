﻿using System;
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

        #region Fields

        private TcpServerChannel serverChannel;
        private int tcpPort;
        private ObjRef internalRef;
        private bool serverActive = false;
        private static string serverURI = "serverExample.Rem";

        #endregion

        #region IServerObject Members

        public event MessageArrivedEvent MessageArrived;

        public void PublishMessage(string Message)
        {
            SafeInvokeMessageArrived(Message);
        }

        #endregion

        public void StartServer(int port)
        {
            if (serverActive)
                return;

            Hashtable props = new Hashtable();
            props["port"] = port;
            props["name"] = serverURI;

            //Set up for remoting events properly
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            serverChannel = new TcpServerChannel(props, serverProv);

            try
            {
                ChannelServices.RegisterChannel(serverChannel, false);
                internalRef = RemotingServices.Marshal(this, props["name"].ToString());
                serverActive = true;
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
            if (!serverActive)
                return;

            RemotingServices.Unmarshal(internalRef);

            try
            {
                ChannelServices.UnregisterChannel(serverChannel);
            }
            catch (Exception ex)
            {

            }
        }

        private void SafeInvokeMessageArrived(string Message)
        {
            if (!serverActive)
                return;

            if (MessageArrived == null)
                return;         //No Listeners

            MessageArrivedEvent listener = null;
            Delegate[] dels = MessageArrived.GetInvocationList();

            foreach (Delegate del in dels)
            {
                try
                {
                    listener = (MessageArrivedEvent)del;
                    listener.Invoke(Message);
                }
                catch (Exception ex)
                {
                    //Could not reach the destination, so remove it
                    //from the list
                    MessageArrived -= listener;
                }
            }
        }
    }
}

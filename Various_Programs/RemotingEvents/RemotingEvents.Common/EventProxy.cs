using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemotingEvents.Common
{
    public class EventProxy : MarshalByRefObject
    {
        public event MessageArrivedEvent MessageArrived;

        public override object InitializeLifetimeService()
        {
            return null;            //Returning null holds the object alive until it is explicitly destroyed
        }

        public void LocallyHandleMessageArrived(string msg)
        {
            this.MessageArrived?.Invoke(msg);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemotingEvents.Common
{
    public interface IServerObject
    {
        event MessageArrivedEvent MessageArrived;

        void PublishMessage(string msg);
    }
}

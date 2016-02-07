namespace Empire.Models.EventsArgs
{
    using System;
    using Interfaces;

    public class ResourceProducerEventArgs : EventArgs
    {
        public ResourceProducerEventArgs(IResource resource)
        {
            this.Resource = resource;
        }
        public IResource Resource { get; private set; }
    }
}
namespace Empire.Models
{
    using System;
    using Enum;
    using Interfaces;

    public class Resource : IResource
    {
        private int qty;

        public Resource(ResourceType resourceType, int qty)
        {
            this.ResourceType = resourceType;
            this.Quantity = qty;
        }

        public ResourceType ResourceType { get; private set; }

        public int Quantity
        {
            get { return this.qty; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Resource quantity cannot be null");
                }

                this.qty = value;
            }
        }
    }
}
namespace Empire.Models.EventsArgs
{
    using System;
    using Interfaces;

    public class UnitProducerEventArgs : EventArgs
    {
        public UnitProducerEventArgs(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; private set; }
    }
}
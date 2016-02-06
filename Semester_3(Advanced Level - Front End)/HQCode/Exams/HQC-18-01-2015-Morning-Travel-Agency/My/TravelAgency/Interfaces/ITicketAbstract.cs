namespace TravelAgency.Interfaces
{
    using System;

    public interface ITicketAbstract : IComparable<ITicketAbstract>
    {
        string DeparturePoint { get; }

        string ArrivalPoint { get; }

        DateTime DepartureTime { get; }

        decimal TicketPrice { get; }

        string UniqueKey { get; }

        string FromToKey { get; }
    }
}
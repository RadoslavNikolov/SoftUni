namespace Huy_Phuong.Infrastructure
{
    using System;

    public interface IPerformance
    {
        ITheatre Theatre { get;}

        string Name { get;}

        DateTime StartTime { get;}

        TimeSpan Duration { get;}

        decimal TicketPrice { get; }

        string Print();
    }
}
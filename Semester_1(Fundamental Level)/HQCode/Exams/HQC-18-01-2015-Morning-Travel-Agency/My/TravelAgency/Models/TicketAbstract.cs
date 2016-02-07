namespace TravelAgency.Models
{
    using System;
    using Enums;
    using Helpers;
    using Interfaces;

    public abstract class TicketAbstract : ITicketAbstract
    {
        protected TicketAbstract(string departurePoint, string arrivalPoint, DateTime departureTime, decimal ticketPrice, TicketType ticketType)
        {
            this.DeparturePoint = departurePoint;
            this.ArrivalPoint = arrivalPoint;
            this.DepartureTime = departureTime;
            this.TicketPrice = ticketPrice;
            this.Type = ticketType;
        }

        public string DeparturePoint { get; private set; }

        public string ArrivalPoint { get; private set; }

        public DateTime DepartureTime { get; private set; }

        public decimal TicketPrice { get; private set; }

        public TicketType Type { get; private set; }

        public abstract string UniqueKey { get; }

        public string FromToKey
        {
            get { return Utils.CreateDepartureArrivalKey(this.DeparturePoint, this.ArrivalPoint); }
        }

        public int CompareTo(ITicketAbstract otherTicket)
        {
            int result = this.DepartureTime.CompareTo(otherTicket.DepartureTime);

            if (result == 0)
            {
                result = string.Compare(this.GetType().Name, otherTicket.GetType().Name, StringComparison.Ordinal);
            }

            if (result == 0)
            {
                result = this.TicketPrice.CompareTo(otherTicket.TicketPrice);
            }

            return result;
        }

        public override string ToString()
        {
            var output = string.Format("[{0}; {1}; {2:F2}]", this.DepartureTime.ToString("dd.MM.yyyy HH:mm"), this.ExtractTicketType(), this.TicketPrice);

            return output;
        }

        protected string ExtractTicketType()
        {
            var neededResul = this.GetType().Name.Replace("Ticket", string.Empty).ToLower();

            return neededResul;
        }
    }
}
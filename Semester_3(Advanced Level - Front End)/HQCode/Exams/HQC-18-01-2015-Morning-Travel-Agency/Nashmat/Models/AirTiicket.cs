using System;

namespace TravelAgency.Models
{
    using Enums;
    using Helpers;
    using Helpers.Custom_Exceptions;

    public class AirTicket : TicketAbstract
    {
        public AirTicket(string flightNumber, string departurePoint, string arrivalPoint, string airLineName, DateTime departureTime, decimal ticketPrice)
            : base(departurePoint, arrivalPoint, departureTime, ticketPrice, TicketType.Air)
        {
            this.FlightNumber = flightNumber;
            this.AirlineName = airLineName;
        }

        public string FlightNumber { get; private set; }

        public string AirlineName { get; private set; }

        public override string UniqueKey
        {
            get
            {
                return TicketUtils.GetUniqueKeyForAirTicket(this.FlightNumber);
            }
        }
    }
}
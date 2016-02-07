namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Helpers.Custom_Exceptions;
    using Interfaces;

    public class AddAir : CommandAbstract
    {
        public AddAir(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {         
        }

        public override string Execute()
        {
            string flightNumber = this.Parameters[0].Trim();
            string departurePoint = this.Parameters[1].Trim();
            string arrivalPoint = this.Parameters[2].Trim();
            string airlineName = this.Parameters[3].Trim();
            DateTime departureTime = Utils.ParseDateTime(this.Parameters[4].Trim());
            decimal ticketPrice = TicketUtils.ParsePrice(this.Parameters[5].Trim());

            string result = this.TicketCatalog.AddAirTicket(flightNumber, departurePoint, arrivalPoint, airlineName, departureTime, ticketPrice);

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} with parameters: {1}", this.GetType().Name, string.Join("/", this.Parameters));
        }
    }
}
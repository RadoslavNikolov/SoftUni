namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            string flightNumber = this.Parameters[0];
            string departurePoint = this.Parameters[1];
            string arrivalPoint = this.Parameters[2];
            string airlineName = this.Parameters[3];
            DateTime departureTime = Utils.ParseDateTime(this.Parameters[4]);
            decimal ticketPrice = TicketUtils.ParsePrice(this.Parameters[5]);

            string result = this.TicketCatalog.AddAirTicket(flightNumber, departurePoint, arrivalPoint, airlineName,
                departureTime, ticketPrice);

            return result;
        }

        public override string ToString()
        {
            return String.Format("{0} with parameters: {1}", this.GetType().Name, String.Join("/", this.Parameters));
        }
    }
}
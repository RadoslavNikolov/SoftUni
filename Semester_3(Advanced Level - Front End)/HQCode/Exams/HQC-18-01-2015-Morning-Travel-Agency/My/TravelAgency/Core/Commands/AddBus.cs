namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Helpers.Custom_Exceptions;
    using Interfaces;

    public class AddBus : CommandAbstract
    {
        public AddBus(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            string departurePoint = this.Parameters[0].Trim();
            string arrivalPoint = this.Parameters[1].Trim();
            string travelCompanyName = this.Parameters[2].Trim();
            DateTime departureTime = Utils.ParseDateTime(this.Parameters[3].Trim());
            decimal ticketPrice = TicketUtils.ParsePrice(this.Parameters[4].Trim());

            string result = this.TicketCatalog.AddBusTicket(departurePoint, arrivalPoint, travelCompanyName, departureTime, ticketPrice);

            return result;
        }
    }
}
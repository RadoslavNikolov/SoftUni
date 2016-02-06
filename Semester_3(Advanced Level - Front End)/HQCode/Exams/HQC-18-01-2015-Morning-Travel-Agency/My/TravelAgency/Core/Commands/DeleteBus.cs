namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class DeleteBus : CommandAbstract
    {
        public DeleteBus(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            string departurePoint = this.Parameters[0].Trim();
            string arrivalPoint = this.Parameters[1].Trim();
            string travelCompanyName = this.Parameters[2].Trim();
            DateTime departureTime = Utils.ParseDateTime(this.Parameters[3].Trim());
            string result = this.TicketCatalog.DeleteBusTicket(departurePoint, arrivalPoint, travelCompanyName, departureTime);

            return result;
        }
    }
}
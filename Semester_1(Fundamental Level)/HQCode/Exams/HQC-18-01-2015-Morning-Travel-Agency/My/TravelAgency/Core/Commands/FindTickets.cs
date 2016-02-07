namespace TravelAgency.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class FindTickets : CommandAbstract
    {
        public FindTickets(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            string departurePoint = this.Parameters[0].Trim();
            string arrivalPoint = this.Parameters[1].Trim();
            string result = this.TicketCatalog.FindTickets(departurePoint, arrivalPoint);

            return result;
        }
    }
}
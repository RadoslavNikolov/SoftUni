namespace TravelAgency.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class DeleteAir : CommandAbstract
    {
        public DeleteAir(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            string flightNumber = this.Parameters[0];
            string commandResult = this.TicketCatalog.DeleteAirTicket(flightNumber);

            return commandResult;
        }
    }
}
namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class DeleteTrain : CommandAbstract
    {
        public DeleteTrain(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            string departurePoint = this.Parameters[0].Trim();
            string arrivalPoint = this.Parameters[1].Trim();
            DateTime departureTime = Utils.ParseDateTime(this.Parameters[2].Trim());
            string result = this.TicketCatalog.DeleteTrainTicket(departurePoint, arrivalPoint, departureTime);

            return result;
        }
    }
}
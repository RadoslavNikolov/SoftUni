namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class FindTicketsInInterval : CommandAbstract
    {
        public FindTicketsInInterval(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            DateTime startTime = Utils.ParseDateTime(this.Parameters[0].Trim());
            DateTime endTime = Utils.ParseDateTime(this.Parameters[1].Trim());
            string result = this.TicketCatalog.FindTicketsInInterval(startTime, endTime);

            return result;
        }
    }
}
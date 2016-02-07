namespace TravelAgency.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Helpers.Custom_Exceptions;
    using Interfaces;

    public class AddTrain : CommandAbstract
    {
        public AddTrain(IList<string> parameters, ITicketCatalog ticketCatalog) 
            : base(parameters, ticketCatalog)
        {
        }

        public override string Execute()
        {
            string departurePoint = this.Parameters[0].Trim();
            string arrivalPoint = this.Parameters[1].Trim();
            DateTime departureTime = Utils.ParseDateTime(this.Parameters[2].Trim());
            decimal regularTicketPrice = TicketUtils.ParsePrice(this.Parameters[3].Trim());
            decimal studentTicketPrice = TicketUtils.ParsePrice(this.Parameters[4].Trim());

            string result = this.TicketCatalog.AddTrainTicket(departurePoint, arrivalPoint, departureTime, regularTicketPrice, studentTicketPrice);

            return result;
        }
    }
}
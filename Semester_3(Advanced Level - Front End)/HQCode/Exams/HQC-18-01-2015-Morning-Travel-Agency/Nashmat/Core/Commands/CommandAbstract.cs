namespace TravelAgency.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CommandAbstract : ICommand
    {
        protected CommandAbstract(IList<string> parameters, ITicketCatalog ticketCatalog)
        {
            this.Parameters = parameters;
            this.TicketCatalog = ticketCatalog;
        }

        protected readonly ITicketCatalog TicketCatalog;

        protected IList<string> Parameters { get; private set; }

        public abstract string Execute();
    }
}
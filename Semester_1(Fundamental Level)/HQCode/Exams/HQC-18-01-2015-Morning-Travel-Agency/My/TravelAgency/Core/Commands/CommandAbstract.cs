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

        protected ITicketCatalog TicketCatalog { get; private set; }

        protected IList<string> Parameters { get; private set; }

        public abstract string Execute();
    }
}
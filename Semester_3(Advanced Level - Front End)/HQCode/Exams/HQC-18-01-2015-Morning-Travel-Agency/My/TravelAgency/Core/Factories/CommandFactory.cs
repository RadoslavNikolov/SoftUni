namespace TravelAgency.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Helpers.Custom_Exceptions;
    using Interfaces;

    public class CommandFactory : ICommandFactory
    {
        private readonly ITicketCatalog ticketCatalog;

        public CommandFactory(ITicketCatalog ticketCatalog)
        {
            this.ticketCatalog = ticketCatalog;
        }

        public CommandFactory()
            : this(new TicketCatalog())
        {     
        }

        public ICommand CreateCommand(string commandLine)
        {
            int firstSpaceIndex = commandLine.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                throw new InvalidCommandException("Invalid command!");
            }

            string commandName = commandLine.Substring(0, firstSpaceIndex).Trim(); 
            commandLine = commandLine.Substring(firstSpaceIndex + 1).Trim();
            string[] parameters = commandLine.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == commandName.ToLowerInvariant());

            if (type == null)
            {
                throw new InvalidCommandException("Invalid command!");
            }

            var commad = (ICommand)Activator.CreateInstance(type, parameters, this.ticketCatalog);

            return commad;
        }
    }
}
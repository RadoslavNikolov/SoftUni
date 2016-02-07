namespace TravelAgency
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Core.Factories;
    using Data;
    using Interfaces;
    using IO;

    public static class TravelAgencyProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ITicketCatalog ticketCatalog = new TicketCatalog();
            IReaderWriter consoleReaderWriter = new ConsoleReaderWriter();
            ICommandFactory commandFactory = new CommandFactory(ticketCatalog);
            ICommandManager commandManager = new CommandManager(commandFactory);

            IRunnable engine = new Engine(commandManager, consoleReaderWriter);
            engine.Run();
        }
    }
}

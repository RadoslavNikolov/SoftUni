namespace TravelAgency
{
    using Data;
    using Execution;
    using Execution.Factories;
    using Interfaces;
    using IO;

    public static class TravelAgencyProgram
    {
        static void Main()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            IReaderWriter consoleReaderWriter = new ConsoleReaderWriter();
            ICommandFactory commandFactory = new CommandFactory(ticketCatalog);
            ICommandManager commandManager = new CommandManager(commandFactory);

            IRunnable engine = new Engine(commandManager, consoleReaderWriter);
            engine.Run();
        }
    }
}

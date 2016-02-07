namespace Huy_Phuong
{
    using Core;
    using Core.Factories;
    using Infrastructure;
    using IO;

    public class TheatreProgram
    {
        static void Main()
        {
            ITheatreData data = new TheatreData();
            IReaderWriter consoleReaderWriter = new ConsoleReadWriter();
            ICommandFactory commandFactory = new CommandFactory(data);
            ICommandManager commandManager = new CommandManager(commandFactory);

            IRunnable engine = new Engine(commandManager, consoleReaderWriter);
            engine.Run();
        } 
    }
}
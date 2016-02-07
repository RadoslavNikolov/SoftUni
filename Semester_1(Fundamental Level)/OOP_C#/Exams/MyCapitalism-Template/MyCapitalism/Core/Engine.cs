namespace MyCapitalism.Core
{
    using Interfaces;

    public class Engine : IRunnable
    {
        private readonly ICommandManager commandManager;
        private readonly IReaderWriter readerWriter;

        public Engine(ICommandManager commandManager, IReaderWriter readerWriter)
        {
            this.commandManager = commandManager;
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.readerWriter.Read();

                this.commandManager.ExecuteCommand(input);
            }
        }
    }
}
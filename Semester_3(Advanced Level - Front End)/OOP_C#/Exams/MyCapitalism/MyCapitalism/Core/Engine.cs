namespace MyCapitalism.Core
{
    using System;
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
                try
                {
                    this.readerWriter.Print(this.commandManager.ExecuteCommand(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }         
            }
        }
    }
}
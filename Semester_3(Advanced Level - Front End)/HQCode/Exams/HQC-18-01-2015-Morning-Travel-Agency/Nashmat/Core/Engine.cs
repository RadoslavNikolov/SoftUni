namespace TravelAgency.Execution
{
    using System;
    using Helpers.Custom_Exceptions;
    using Interfaces;
    using IO;

    public class Engine : IRunnable
    {
        private readonly ICommandManager commandManager;
        private readonly IReaderWriter readerWriter;

        public Engine(ICommandManager commandManager, IReaderWriter readerWriter)
        {
            this.commandManager = commandManager;
            this.readerWriter = readerWriter;
        }

        public Engine()
            : this(new CommandManager(), new ConsoleReaderWriter())
        {
            
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = this.readerWriter.Read();

                if (inputLine == null)
                {
                    break;
                }

                inputLine = inputLine.Trim();

                if (!string.IsNullOrEmpty(inputLine))
                {
                    try
                    {
                        string commandResult = this.commandManager.ExecuteCommand(inputLine);

                        if (!string.IsNullOrWhiteSpace(commandResult))
                        {
                            this.readerWriter.Print(commandResult);
                        }
                    }
                    catch (InvalidCommandException ex)
                    {
                        this.readerWriter.Print(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        this.readerWriter.Print(ex.Message);
                    }
                }
            }
        }
    }
}
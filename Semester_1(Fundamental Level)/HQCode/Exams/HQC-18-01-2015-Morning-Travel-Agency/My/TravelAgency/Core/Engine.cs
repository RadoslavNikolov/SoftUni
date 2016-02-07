namespace TravelAgency.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Helpers.Custom_Exceptions;
    using Interfaces;
    using IO;

    public class Engine : IRunnable
    {
        private static readonly Queue<string> OutputQueue = new Queue<string>();
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
                            OutputQueue.Enqueue(commandResult);
                        }
                    }
                    catch (InvalidCommandException ex)
                    {
                        OutputQueue.Enqueue(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        OutputQueue.Enqueue(ex.Message);
                    }
                }

                if (OutputQueue.Count > 0)
                {
                    this.readerWriter.Print(OutputQueue.Dequeue());
                }
            }

            while (OutputQueue.Count > 0)
            {
                this.readerWriter.Print(OutputQueue.Dequeue());
            }
        }
    }
}
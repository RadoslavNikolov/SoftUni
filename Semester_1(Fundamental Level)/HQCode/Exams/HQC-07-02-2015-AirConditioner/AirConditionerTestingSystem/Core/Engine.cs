namespace AirConditionerTestingSystem.Core
{
    using System;
    using System.Text;
    using Helpers.CustomException;
    using Interfaces;
    using UI;

    public class Engine : IRunnable
    {
        private readonly IUserInterface userInterface;
        private readonly ICommandManager commandManager;

        public Engine(ICommandManager commandManager, IUserInterface userInterface)
        {
            ////DI: Ioc example. This way we can moq everithing we want
            this.commandManager = commandManager;
            this.userInterface = userInterface;
        }

        public Engine()
            : this(new CommandManager(), new ConsoleUserInterface())
        {       
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = this.userInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    break;
                }

                inputLine = inputLine.Trim();

                try
                {
                    string commandResult = this.commandManager.ExecuteCommand(inputLine);

                    if (!string.IsNullOrWhiteSpace(commandResult))
                    {
                        this.userInterface.WriteLine(commandResult);
                    }
                }
                catch (DuplicateEntryException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
                catch (NonExistantEntryException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }   
    }
}

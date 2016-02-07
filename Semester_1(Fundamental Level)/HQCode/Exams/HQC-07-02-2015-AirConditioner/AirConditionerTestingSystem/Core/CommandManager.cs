namespace AirConditionerTestingSystem.Core
{
    using Factories;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        private readonly ICommandFactory commandFactory;

        public CommandManager(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public CommandManager()
            : this(new CommandFactory())
        {
        }

        public string ExecuteCommand(string commandLine)
        {
            var command = this.commandFactory.CreateCommand(commandLine);
            string output = command.Execute();

            return output;
        }
    }
}
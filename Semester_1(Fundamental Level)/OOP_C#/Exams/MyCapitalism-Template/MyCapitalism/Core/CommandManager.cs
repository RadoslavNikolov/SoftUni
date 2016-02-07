namespace MyCapitalism.Core
{
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        private readonly ICommandFactory commandFactory;

        public CommandManager(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void ExecuteCommand(string commandLine)
        {
            var command = this.commandFactory.CreateCommand(commandLine);
            command.Execute();
        }
    }
}
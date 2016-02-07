namespace Huy_Phuong.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Infrastructure;
    public class CommandFactory : ICommandFactory
    {
        private readonly ITheatreData theatreData;

        public CommandFactory(ITheatreData theatreData)
        {
            this.theatreData = theatreData;
        }

        public ICommand CreateCommand(string commandLine)
        {
            commandLine = commandLine.TrimEnd(')');
            string[] commandParts = commandLine.Split(new[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandParts[0];
            string[] parameters = null;

            if (commandParts.Length > 1)
            {
                parameters = commandParts[1].Replace(")", "").Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == commandName.ToLowerInvariant());

            if (type == null)
            {
                throw new ArgumentException("Unknown command");
            }

            var commad = (ICommand)Activator.CreateInstance(type, parameters, this.theatreData);

            return commad;
        }
    }
}
namespace MyCapitalism.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography;
    using Interfaces;

    public class CommandFactory : ICommandFactory
    {
        private readonly ICapitalismData capitalismData;
        private readonly IReaderWriter readerWriter;

        public CommandFactory(ICapitalismData capitalismData, IReaderWriter readerWriter)
        {
            this.capitalismData = capitalismData;
            this.readerWriter = readerWriter;
        }

        public ICommand CreateCommand(string commandLine)
        {
            string[] commandParts = commandLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandParts[0].Replace("-","");
            string[] parameters = null;
            if (commandParts.Length > 1)
            {
                parameters = commandParts.Skip(1).ToArray();
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == commandName.ToLowerInvariant());

            if (type == null)
            {
                throw new ArgumentException("Unknown command");
            }

            var commad = (ICommand)Activator.CreateInstance(type, parameters, capitalismData, readerWriter);

            return commad;
        }
    }
}
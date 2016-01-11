namespace Blobs.Core.Factories
{
    using System;
    using System.CodeDom;
    using System.Linq;
    using System.Reflection;
    using Infrastructure;

    public class CommandFactory : ICommandFactory
    {
        private readonly IBlobsData blobsData;
        private readonly IUnitFactory unitFactory;


        public CommandFactory(IBlobsData blobsData, IUnitFactory unitFactory)
        {
            this.blobsData = blobsData;
            this.unitFactory = unitFactory;
        }

        public ICommand CreateCommand(string commandLine)
        {
            string[] commandParts = commandLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandParts[0].Replace("-", "");
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

            var commad = (ICommand)Activator.CreateInstance(type, parameters, this.blobsData, this.unitFactory);

            return commad;
        }
    }
}
namespace AirConditionerTestingSystem.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Helpers;
    using Interfaces;

    public class CommandFactory : ICommandFactory
    {
        private readonly IConditionerController bussinesCatalog;

        public CommandFactory(IConditionerController bussinesCatalog)
        {
            this.bussinesCatalog = bussinesCatalog;
        }

        public CommandFactory()
            : this(new ConditionerController(new ConditionerDataBase()))
        {
        }

        public ICommand CreateCommand(string commandLine)
        {
            int firstSpaceIndex = commandLine.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            string commandName = commandLine.Substring(0, firstSpaceIndex).Trim();
            string[] parameters = commandLine.Substring(firstSpaceIndex).Trim()
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == commandName.ToLowerInvariant());

            if (type == null)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            var commad = (ICommand)Activator.CreateInstance(type, parameters, this.bussinesCatalog);

            return commad;
        }
    }
}
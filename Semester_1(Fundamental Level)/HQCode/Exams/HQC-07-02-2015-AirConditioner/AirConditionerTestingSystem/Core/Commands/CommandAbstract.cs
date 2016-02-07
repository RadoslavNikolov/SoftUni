namespace AirConditionerTestingSystem.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CommandAbstract : ICommand
    {
        protected CommandAbstract(IList<string> parameters, IConditionerController bussinesCatalog)
        {
            this.Parameters = parameters;
            this.BussinesCatalog = bussinesCatalog;
        }

        protected IConditionerDataBase ConditionerData { get; private set; }

        protected IConditionerController BussinesCatalog { get; private set; }

        protected IList<string> Parameters { get; private set; }

        public abstract string Execute();
    }
}
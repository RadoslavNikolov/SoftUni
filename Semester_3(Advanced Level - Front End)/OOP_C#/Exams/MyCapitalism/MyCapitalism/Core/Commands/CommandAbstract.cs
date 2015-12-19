namespace MyCapitalism.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CommandAbstract : ICommand
    {
        protected readonly ICapitalismData Data;

        protected CommandAbstract(IList<string> parameters, ICapitalismData data)
        {
            this.Parameters = parameters;
            this.Data = data;
        }



        public IList<string> Parameters { get; set; }

        public abstract string Execute();
    }
}
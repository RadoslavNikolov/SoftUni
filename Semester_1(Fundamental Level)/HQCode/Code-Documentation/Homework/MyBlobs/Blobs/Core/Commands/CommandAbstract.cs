namespace Blobs.Core.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure;

    public abstract class CommandAbstract : ICommand
    {
        protected CommandAbstract(IList<string> parameters, IBlobsData data, IUnitFactory unitFactory)
        {
            this.Parameters = parameters;
            this.Data = data;
            this.UnitFactory = unitFactory;
            this.Output = new StringBuilder();
        }

        protected readonly IBlobsData Data;

        protected readonly IUnitFactory UnitFactory;

        public StringBuilder Output { get; private set; }

        public IList<string> Parameters { get; private set; }

        public abstract string Execute();
    }
}
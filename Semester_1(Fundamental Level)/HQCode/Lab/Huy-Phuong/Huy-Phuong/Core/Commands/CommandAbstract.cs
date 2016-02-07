namespace Huy_Phuong.Core.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure;
    public abstract class CommandAbstract : ICommand
    {
        protected CommandAbstract(IList<string> parameters, ITheatreData data)
        {
            this.Parameters = parameters;
            this.Data = data;
        }

        protected readonly ITheatreData Data;

        protected IList<string> Parameters { get; private set; }

        public abstract string Execute();
    }
}
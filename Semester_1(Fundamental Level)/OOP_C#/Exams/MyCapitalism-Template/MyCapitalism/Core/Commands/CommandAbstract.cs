namespace MyCapitalism.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CommandAbstract : ICommand
    {
        protected readonly ICapitalismData Data;
        protected readonly IReaderWriter ReaderWriter;

        protected CommandAbstract(IEnumerable<string> parameters, ICapitalismData data, IReaderWriter readerWriter)
        {
            this.Parameters = parameters;
            this.Data = data;
            this.ReaderWriter = readerWriter;
        }



        public IEnumerable<string> Parameters { get; set; }

        public abstract void Execute();
    }
}
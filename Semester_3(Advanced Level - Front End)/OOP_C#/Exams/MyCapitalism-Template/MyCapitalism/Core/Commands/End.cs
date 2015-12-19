namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class End : CommandAbstract
    {
        public End(IEnumerable<string> parameters, ICapitalismData data, IReaderWriter readerWriter) 
            : base(parameters, data, readerWriter)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
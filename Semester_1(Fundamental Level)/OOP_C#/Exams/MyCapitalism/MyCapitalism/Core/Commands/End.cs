namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class End : CommandAbstract
    {
        public End(IList<string> parameters, ICapitalismData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return "";
        }
    }
}
namespace Blobs.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Infrastructure;

    public class Drop : CommandAbstract
    {
        public Drop(IList<string> parameters, IBlobsData data, IUnitFactory unitFactory) 
            : base(parameters, data, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return "";
        }
    }
}
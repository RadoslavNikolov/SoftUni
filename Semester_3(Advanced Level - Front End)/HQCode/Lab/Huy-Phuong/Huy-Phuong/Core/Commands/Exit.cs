namespace Huy_Phuong.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Infrastructure;

    public class Exit : CommandAbstract
    {
        public Exit(IList<string> parameters, ITheatreData data) : base(parameters, data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "";
        }
    }
}
namespace AirConditionerTestingSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class Status : CommandAbstract
    {
        public Status(IList<string> parameters, IConditionerController bussinesCatalog) 
            : base(parameters, bussinesCatalog)
        {
        }

        public override string Execute()
        {
            if (this.Parameters.Count != 0)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            string result = this.BussinesCatalog.Status();

            return result;
        }
    }
}
namespace AirConditionerTestingSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class FindAirConditioner : CommandAbstract
    {
        public FindAirConditioner(IList<string> parameters, IConditionerController bussinesCatalog) 
            : base(parameters, bussinesCatalog)
        {
        }

        public override string Execute()
        {
            if (this.Parameters.Count != 2)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            string manifacturer = this.Parameters[0];
            string model = this.Parameters[1];

            string result = this.BussinesCatalog.FindAirConditioner(manifacturer, model);

            return result;
        }
    }
}
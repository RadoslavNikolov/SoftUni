namespace AirConditionerTestingSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class RegisterCarAirConditioner : CommandAbstract
    {
        public RegisterCarAirConditioner(IList<string> parameters, IConditionerController bussinesCatalog) 
            : base(parameters, bussinesCatalog)
        {
        }

        public override string Execute()
        {
            if (this.Parameters.Count != 3)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            string manifacturer = this.Parameters[0];
            string model = this.Parameters[1];
            int volumeCoverage = int.Parse(this.Parameters[2]);

            string result = this.BussinesCatalog.RegisterCarAirConditioner(manifacturer, model, volumeCoverage);

            return result;
        }
    }
}
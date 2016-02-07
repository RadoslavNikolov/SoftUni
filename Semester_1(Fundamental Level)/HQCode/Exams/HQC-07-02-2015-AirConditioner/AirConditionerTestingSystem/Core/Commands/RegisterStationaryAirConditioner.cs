namespace AirConditionerTestingSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class RegisterStationaryAirConditioner : CommandAbstract
    {
        public RegisterStationaryAirConditioner(IList<string> parameters, IConditionerController bussinesCatalog) 
            : base(parameters, bussinesCatalog)
        {
        }

        public override string Execute()
        {
            if (this.Parameters.Count != 4)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            string manifacturer = this.Parameters[0];
            string model = this.Parameters[1];
            string energyEfficiencyRating = this.Parameters[2];
            int powerUsage = int.Parse(this.Parameters[3]);

            string result = this.BussinesCatalog.RegisterStationaryAirConditioner(manifacturer, model, energyEfficiencyRating, powerUsage);

            return result;
        }
    }
}
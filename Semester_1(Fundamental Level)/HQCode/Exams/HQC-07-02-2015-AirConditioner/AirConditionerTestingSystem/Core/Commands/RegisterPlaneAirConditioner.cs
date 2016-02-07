namespace AirConditionerTestingSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class RegisterPlaneAirConditioner : CommandAbstract
    {
        public RegisterPlaneAirConditioner(IList<string> parameters, IConditionerController bussinesCatalog) 
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
            int volumeCoverage = int.Parse(this.Parameters[2]);
            string electricityUsed = this.Parameters[3];

            string result = this.BussinesCatalog.RegisterPlaneAirConditioner(manifacturer, model, volumeCoverage, electricityUsed);

            return result;
        }
    }
}
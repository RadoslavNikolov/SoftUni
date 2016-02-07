namespace AirConditionerTestingSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;

    public class FindAllReportsByManufacturer : CommandAbstract
    {
        public FindAllReportsByManufacturer(IList<string> parameters, IConditionerController bussinesCatalog) : base(parameters, bussinesCatalog)
        {
        }

        public override string Execute()
        {
            if (this.Parameters.Count != 1)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }

            string manifacturer = this.Parameters[0];

            string result = this.BussinesCatalog.FindAllReportsByManufacturer(manifacturer);

            return result;
        }
    }
}
namespace Huy_Phuong.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Infrastructure;

    public class AddPerformance : CommandAbstract
    {
        public AddPerformance(IList<string> parameters, ITheatreData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            this.ValidateInputParameters();
            var theatreName = this.Parameters[0];
            var performanceName = this.Parameters[1];

            var timeString = this.Parameters[2].Trim();
            var startDate = DateTime.ParseExact(timeString, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var intervalFormat = "g";
            var interval = TimeSpan.ParseExact(this.Parameters[3], intervalFormat, CultureInfo.InvariantCulture, TimeSpanStyles.None);

            decimal price = 0;
            Decimal.TryParse(this.Parameters[4], out price);

            try
            {
                this.Data.AddPerformance(theatreName, performanceName, startDate, interval, price);
                return "Performance added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private void ValidateInputParameters()
        {
            
        }
    }
}
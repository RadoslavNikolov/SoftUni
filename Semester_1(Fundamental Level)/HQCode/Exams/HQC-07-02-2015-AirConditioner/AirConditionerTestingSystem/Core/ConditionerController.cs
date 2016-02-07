namespace AirConditionerTestingSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Helpers;
    using Interfaces;
    using Models;

    public class ConditionerController : IConditionerController
    {
        private readonly IConditionerDataBase db;

        public ConditionerController(IConditionerDataBase db)
        {
            this.db = db;
        }

        ////Bug: return instead of throw
        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            AirConditioner airConditioner = new AirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.db.AddAirConditioner(airConditioner);

            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        ////Bug: return instead of throw
        public string RegisterCarAirConditioner(string manufacturer, string model,  int volumeCoverage)
        {
            AirConditioner airConditioner = new AirConditioner(manufacturer, model, volumeCoverage);
            this.db.AddAirConditioner(airConditioner);

            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }
    
        /// <summary>
        /// Registers the plane air conditioner.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <param name="volumeCoverage">The volume coverage.</param>
        /// <param name="electricityUsed">The electricity used.</param>
        /// <returns>Returns message with controller command execution status</returns>
        ////Bug: return instead of throw
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            AirConditioner airConditioner = new AirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            this.db.AddAirConditioner(airConditioner);

            ////Bug: Constants.Test instaed of Constants.Register
            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        ////Bug: return instead of throw
        public string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.db.GetAirConditioner(manufacturer, model);
            var mark = airConditioner.Test();
            var newReport = new Report(airConditioner.Manufacturer, airConditioner.Model, mark);
            this.db.AddReport(newReport);

            return string.Format(Constants.TEST, model, manufacturer);
        }
     
        /// <summary>
        /// Finds the air conditioner.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="model">The model.</param>
        /// <returns>Returns message with controller command execution status</returns>
        /// ////Bug: return instead of throw
        public string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.db.GetAirConditioner(manufacturer, model);

            return airConditioner.ToString();
        }

        ////Bug: return instead of throw
        public string FindReport(string manufacturer, string model)
        {
            Report report = this.db.GetReport(manufacturer, model);

            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = this.db.GetReportsByManufacturer(manufacturer);

            if (reports.Count == 0)
            {
                return Constants.Noreports;
            }

            //reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));

            return reportsPrint.ToString();
        }

        /// <summary>
        /// Statuses this instance.
        /// </summary>
        /// <returns>Returns message with controller command execution status</returns>
        public string Status()
        {
            int reports = this.db.GetReportsCount();

            int airConditioners = this.db.GetAirConditionersCount();

            if (reports == 0 || airConditioners == 0)
            {
                return string.Format(Constants.STATUS, 0.0d);
            }

            double percent = reports / (double)airConditioners;
            percent = percent * 100.0;

            return string.Format(Constants.STATUS, percent);
        }
    }
}
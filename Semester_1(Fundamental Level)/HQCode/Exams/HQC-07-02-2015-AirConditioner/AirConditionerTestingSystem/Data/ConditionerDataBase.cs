namespace AirConditionerTestingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Helpers;
    using Helpers.CustomException;
    using Interfaces;
    using Models;

    public class ConditionerDataBase : IConditionerDataBase
    {
        ////Bug: this can be bottleneck, because of using lists. Best way is to use some sort of dictionary with unique key, builded from manifacturer name and model

        private readonly Dictionary<string, AirConditioner> airConditionersByManifacturerAndModel;
        private readonly Dictionary<string, Report> reportsByManifacturerAndModel;
        private readonly List<Report> reportsByManifacturer;
 
        public ConditionerDataBase()
        {
            this.airConditionersByManifacturerAndModel = new Dictionary<string, AirConditioner>();
            this.reportsByManifacturerAndModel = new Dictionary<string, Report>();
            this.reportsByManifacturer = new List<Report>();
        }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            string uniqueKey = Utils.GenerateUniqueKey(airConditioner.Manufacturer, airConditioner.Model);

            if (this.airConditionersByManifacturerAndModel.ContainsKey(uniqueKey))
            {
                throw new DuplicateEntryException(Constants.DUPLICATE);
            }

            this.airConditionersByManifacturerAndModel.Add(uniqueKey, airConditioner);
        }
        
        ////Not necessary for now
        public void RemoveAirConditioner(AirConditioner airConditioner)
        {
            string uniqueKey = Utils.GenerateUniqueKey(airConditioner.Manufacturer, airConditioner.Model);

            if (!this.airConditionersByManifacturerAndModel.ContainsKey(uniqueKey))
            {
                throw new NonExistantEntryException(Constants.NONEXIST);
            }

            this.airConditionersByManifacturerAndModel.Remove(uniqueKey);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            string uniqueKey = Utils.GenerateUniqueKey(manufacturer, model);

            if (!this.airConditionersByManifacturerAndModel.ContainsKey(uniqueKey))
            {
                throw new NonExistantEntryException(Constants.NONEXIST);
            }

            ////Bug: x.First() instead of .Where().First(); Also is possible bottleneck
            ////return this.airConditioners.First(x => x.Manufacturer == manufacturer && x.Model == model);

            return this.airConditionersByManifacturerAndModel[uniqueKey];
        }

        public int GetAirConditionersCount()
        {
            return this.airConditionersByManifacturerAndModel.Count;
        }

        public void AddReport(Report report)
        {
            string uniqueKey = Utils.GenerateUniqueKey(report.Manufacturer, report.Model);

            if (this.reportsByManifacturerAndModel.ContainsKey(uniqueKey))
            {
                throw new DuplicateEntryException(Constants.DUPLICATE);
            }

            this.reportsByManifacturerAndModel.Add(uniqueKey, report);
            this.reportsByManifacturer.Add(report);
        }

        ////Not necessary for now
        public void RemoveReport(Report report)
        {
            string uniqueKey = Utils.GenerateUniqueKey(report.Manufacturer, report.Model);

            if (!this.airConditionersByManifacturerAndModel.ContainsKey(uniqueKey))
            {
                throw new NonExistantEntryException(Constants.NONEXIST);
            }

            this.reportsByManifacturerAndModel.Remove(uniqueKey);
        }

        public Report GetReport(string manufacturer, string model)
        {
            string uniqueKey = Utils.GenerateUniqueKey(manufacturer, model);

            if (!this.reportsByManifacturerAndModel.ContainsKey(uniqueKey))
            {
                throw new NonExistantEntryException(Constants.NONEXIST);
            }

            return this.reportsByManifacturerAndModel[uniqueKey];

            ////Bug: x.First() instead of .Where().First();  Also is possible bottleneck
            ////return this.reprots.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetReportsCount()
        {
            return this.reportsByManifacturerAndModel.Count;
        }

        public List<Report> GetReportsByManufacturer(string manufacturer)
        {
            var results = this.reportsByManifacturer
                .Where(r => r.Manufacturer == manufacturer)
                .OrderBy(r => r.Model)
                .ToList();

            return results;
        }
    }
}
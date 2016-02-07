namespace AirConditionerTestingSystem.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IConditionerDataBase
    {
        void AddAirConditioner(AirConditioner airConditioner);

        void RemoveAirConditioner(AirConditioner airConditioner);

        AirConditioner GetAirConditioner(string manufacturer, string model);

        int GetAirConditionersCount();

        void AddReport(Report report);

        void RemoveReport(Report report);

        Report GetReport(string manufacturer, string model);

        int GetReportsCount();

        List<Report> GetReportsByManufacturer(string manufacturer);
    }
}
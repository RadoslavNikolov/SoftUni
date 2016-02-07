namespace AirConditionerTestingSystem.Interfaces
{
    public interface IConditionerController
    {
        string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage);

        string RegisterCarAirConditioner(string model, string manufacturer, int volumeCoverage);

        string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed);

        string TestAirConditioner(string manufacturer, string model);

        string FindAirConditioner(string manufacturer, string model);

        string FindReport(string manufacturer, string model);

        string FindAllReportsByManufacturer(string manufacturer);

        string Status();
    }
}
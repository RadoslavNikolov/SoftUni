namespace TravelAgency.Helpers
{
    using System;
    using System.Globalization;

    public static class Utils
    {
        public static string CreateDepartureArrivalKey(string departurePoint, string arrivalPoint)
        {
            return string.Format("{0}; {1}", departurePoint, arrivalPoint);
        }

        public static DateTime ParseDateTime(string dateTimeStr)
        {
            DateTime result = DateTime.ParseExact(dateTimeStr, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            return result;
        }
    }
}
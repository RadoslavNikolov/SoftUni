namespace TravelAgency.Helpers.Custom_Exceptions
{
    using System;
    using System.Globalization;

    public static class TicketUtils
    {


        public static string GetUniqueKeyForAirTicket(string flightNumber)
        {
            return flightNumber;
        }

        public static string GetUniqueKeyForTrainTicket(string departurePoint, string arrivalPoint, DateTime departureTime)
        {
            return string.Format("{0};{1};{2}", departurePoint, arrivalPoint, departureTime);
        }

        public static string GetUniqueKeyForBusTicket(string departurePoint, string arrivalPoint, string travelCompany, DateTime departureTime)
        {
            return string.Format("{0};{1};{2};{3}", departurePoint, arrivalPoint, travelCompany, departureTime);
        }

        public static decimal ParsePrice(string priceStr)
        {
            decimal price = 0m;
            decimal.TryParse(priceStr, NumberStyles.Currency, CultureInfo.InvariantCulture, out price);

            return price;
        }
    }
}
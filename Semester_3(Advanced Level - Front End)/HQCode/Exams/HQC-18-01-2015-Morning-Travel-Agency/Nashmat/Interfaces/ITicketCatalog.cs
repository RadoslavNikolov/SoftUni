namespace TravelAgency.Interfaces
{
    using System;
    using Models.Enums;

    // TODO: document this interface
    // Do not modify the interface members
    // Moving the interface to separate namespace is allowed
    // Adding XML documentation is allowed
    public interface ITicketCatalog
    {
        // TODO: document this method
        string AddAirTicket(string flightNumber, string departurePoint, string arrivalPoint, string airlineName, DateTime departureTime, decimal ticketPrice);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string departurePoint, string arrivalPoint, DateTime departureTime, decimal regularPrice, decimal studentPrice);

        string DeleteTrainTicket(string departurePoint, string arrivalPoint, DateTime departureTime);

        string AddBusTicket(string departurePoint, string arrivalPoint, string travelCompanyName, DateTime departureTime, decimal ticketPrice);

        // TODO: document this method
        string DeleteBusTicket(string departurePoint, string arrivalPoint, string travelCompanyName, DateTime departureTime);

        // TODO: document this method
        string FindTickets(string departurePoint, string arrivalPoint);

        // TODO: document this method
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType ticketType);
    }
}
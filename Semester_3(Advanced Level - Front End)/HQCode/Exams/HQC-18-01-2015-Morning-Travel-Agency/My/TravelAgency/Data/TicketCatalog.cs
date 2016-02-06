namespace TravelAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helpers;
    using Helpers.Custom_Exceptions;
    using Interfaces;
    using Models;
    using Models.Enums;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly Dictionary<string, ITicketAbstract> ticketByUniqueKey = new Dictionary<string, ITicketAbstract>();
        private readonly MultiDictionary<string, ITicketAbstract> ticketByDestination = new MultiDictionary<string, ITicketAbstract>(true);
        private readonly OrderedMultiDictionary<DateTime, ITicketAbstract> ticketByDepartureTime = new OrderedMultiDictionary<DateTime, ITicketAbstract>(true);
        private int airTicketsCount = 0;
        private int busTicketsCount = 0;
        private int trainTicketsCount = 0;

        public string AddAirTicket(string flightNumber, string departurePoint, string arrivalPoint, string airlineName, DateTime deprtureTime, decimal ticketPrice)
        {
            AirTicket newTicket = new AirTicket(flightNumber, departurePoint, arrivalPoint, airlineName, deprtureTime, ticketPrice);
            string result = this.AddDeleteTicket(newTicket, true);
      
            if (result.Contains("added"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            string uniqueKey = TicketUtils.GetUniqueKeyForAirTicket(flightNumber);
            ITicketAbstract ticketToDelete = this.GetTicketByUniqueKey(uniqueKey);

            if (ticketToDelete == null)
            {
                return "Ticket does not exist";
            }

            string result = this.AddDeleteTicket(ticketToDelete, false);
            this.airTicketsCount--;

            return result;
        }

        public string AddTrainTicket(string departurePoint, string arrivalPoint, DateTime departureTime, decimal regularPrice, decimal studentPrice)
        {
            TrainTicket newTicket = new TrainTicket(departurePoint, arrivalPoint, departureTime, regularPrice, studentPrice);
            string result = this.AddDeleteTicket(newTicket, true);

            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string departurePoint, string arrivalPoint, DateTime departureTime)
        {
            string uniqueKey = TicketUtils.GetUniqueKeyForTrainTicket(departurePoint, arrivalPoint, departureTime);
            ITicketAbstract ticketToDelete = this.GetTicketByUniqueKey(uniqueKey);

            if (ticketToDelete == null)
            {
                return "Ticket does not exist";
            }

            string result = this.AddDeleteTicket(ticketToDelete, false);
            this.trainTicketsCount--;

            return result;
        }

        public string AddBusTicket(string departurePoint, string arrivalPoint, string travelCompanyName, DateTime departureTime, decimal ticketPrice)
        {
            BusTicket newTicket = new BusTicket(departurePoint, arrivalPoint, travelCompanyName, departureTime, ticketPrice);
            string result = this.AddDeleteTicket(newTicket, true);

            if (result.Contains("added"))
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string DeleteBusTicket(string departurePoint, string arrivalPoint, string travelCompanyName, DateTime departureTime)
        {
            string uniqueKey = TicketUtils.GetUniqueKeyForBusTicket(departurePoint, arrivalPoint, travelCompanyName, departureTime);
            ITicketAbstract ticketToDelete = this.GetTicketByUniqueKey(uniqueKey);

            if (ticketToDelete == null)
            {
                return "Ticket does not exist";
            }

            string result = this.AddDeleteTicket(ticketToDelete, false);
            this.busTicketsCount--;

            return result;
        }

        public string FindTickets(string departurePoint, string arrivalPoint)
        {
            string fromToKey = Utils.CreateDepartureArrivalKey(departurePoint, arrivalPoint);

            if (!this.ticketByDestination.ContainsKey(fromToKey))
            {
                return "Not found";
            }

            var ticketsFound = this.ticketByDestination[fromToKey];
            string ticketsAsString = this.ReadTickets(ticketsFound);

            return ticketsAsString;       
        }

        public string FindTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
        {
            DateTime startDateTime = Utils.ParseDateTime(startDateTimeStr);
            DateTime endDateTime = Utils.ParseDateTime(endDateTimeStr);

            var ticketsFound = this.ticketByDepartureTime.Range(startDateTime, true, endDateTime, true).Values;

            if (!ticketsFound.Any())
            {
                return "Not found";
            }

            string ticketsAsString = this.FindTicketsInInterval(startDateTime, endDateTime);
            return ticketsAsString;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketByDepartureTime.Range(startDateTime, true, endDateTime, true).Values;

            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = this.ReadTickets(ticketsFound); 
                
                return ticketsAsString;
            }

            return "Not found";
        }

        public int GetTicketsCount(TicketType ticketType)
        {
            if (ticketType == TicketType.Air)
            {
                return this.airTicketsCount;
            }

            if (ticketType == TicketType.Bus)
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }

        private string ReadTickets(ICollection<ITicketAbstract> tickets)
        {
            ////var sortedTickets = tickets.OrderBy(t => t.DepartureTime)
            ////    .ThenBy(t => t.GetType().Name)
            ////    .ThenBy(t => t.TicketPrice);

            string result = string.Join(" ", tickets.OrderBy(t => t));

            return result;
        }

        private ITicketAbstract GetTicketByUniqueKey(string uniqueKey)
        {
            if (!this.ticketByUniqueKey.ContainsKey(uniqueKey))
            {
                return default(ITicketAbstract);
            }

            return this.ticketByUniqueKey[uniqueKey];
        }

        private string AddDeleteTicket(ITicketAbstract ticket, bool isAdd)
        {
            if (isAdd)
            {
                string key = ticket.UniqueKey;

                if (this.ticketByUniqueKey.ContainsKey(key))
                {
                    return "Duplicate ticket";
                }

                this.ticketByUniqueKey.Add(key, ticket);
                string fromToKey = ticket.FromToKey;
                this.ticketByDestination.Add(fromToKey, ticket);
                this.ticketByDepartureTime.Add(ticket.DepartureTime, ticket);

                return "Ticket added";
            }
            else
            {
                string key = ticket.UniqueKey;
                string fromToKey = ticket.FromToKey;
                DateTime departureKey = ticket.DepartureTime;

                this.ticketByUniqueKey.Remove(key);       
                this.ticketByDestination.Remove(fromToKey, ticket);
                this.ticketByDepartureTime.Remove(departureKey, ticket);
                return "Ticket deleted";
            }
        }
    }
}

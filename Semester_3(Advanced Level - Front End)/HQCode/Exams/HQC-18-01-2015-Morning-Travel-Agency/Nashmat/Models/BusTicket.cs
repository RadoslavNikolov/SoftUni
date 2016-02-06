using System;

namespace TravelAgency.Models
{
    using Enums;
    using Helpers.Custom_Exceptions;

    public class BusTicket : TicketAbstract
    {
        public BusTicket(string departurePoint, string arrivalPoint, string companyName, DateTime departureTime, decimal ticketPrice)
            :base(departurePoint, arrivalPoint, departureTime, ticketPrice, TicketType.Bus)
        {
            this.TravelCompanyName = companyName;
        }

        public string TravelCompanyName { get; private set; }

        //public override string MunfaridKuleed
        //{
        //    get
        //    {
        //        return this.Type + ";;" + this.DeparturePoint + ";" + this.ArrivalPoint + ";" +
        //               this.Company + this.DepartureTime + ";";
        //    }
        //}
        public override string UniqueKey
        {
            get
            {
                return TicketUtils.GetUniqueKeyForBusTicket(this.DeparturePoint, this.ArrivalPoint,
                    this.TravelCompanyName, this.DepartureTime);
            }
        }
    }
}
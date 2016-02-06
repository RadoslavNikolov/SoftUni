namespace TravelAgency.Models
{
    using System;
    using Enums;

    public class BoatTicket : TicketAbstract
    {
        public BoatTicket(string departurePoint, string arrivalPoint, string companyName, DateTime departureTime, decimal ticketPrice)
            : base(departurePoint, arrivalPoint, departureTime, ticketPrice, TicketType.Boat)
        {
            this.BoatCompanyName = companyName;
        }

        public string BoatCompanyName { get; private set; }
        //public override string MunfaridKuleed
        //{
        //    get { return this.Type + ";;" + this.DeparturePoint + ";" + this.ArrivalPoint + ";" + this.Company + this.DepartureTime + ";"; }
        //}
        public override string UniqueKey
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
using System;

namespace TravelAgency.Models
{
    using Enums;
    using Helpers.Custom_Exceptions;

    public class TrainTicket : TicketAbstract
    {
        public TrainTicket(string departurePoint, string arrivalPoint, DateTime departureTime, decimal regularPrice, decimal studentPrice)
            : base(departurePoint, arrivalPoint, departureTime, regularPrice, TicketType.Train)
        {
            this.StudentPrice = studentPrice;
        }

        public decimal StudentPrice { get; private set; }

        public override string UniqueKey
        {
            get
            {
                return TicketUtils.GetUniqueKeyForTrainTicket(this.DeparturePoint, this.ArrivalPoint, this.DepartureTime); 
            }
        }
    }
}

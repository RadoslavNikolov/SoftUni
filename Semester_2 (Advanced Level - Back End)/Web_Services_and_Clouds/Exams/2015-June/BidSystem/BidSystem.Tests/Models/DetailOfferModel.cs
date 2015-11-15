namespace BidSystem.Tests.Models
{
    using System;

    public class DetailOfferModel
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? InitialPrice { get; set; }

        public DateTime? ExpirationDateTime { get; set; }

        public BidModel[] Bids { get; set; }
    }
}
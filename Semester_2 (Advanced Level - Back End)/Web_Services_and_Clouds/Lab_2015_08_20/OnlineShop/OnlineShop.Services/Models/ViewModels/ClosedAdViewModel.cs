namespace OnlineShop.Services.Models.ViewModels
{
    using System;
    using OnlineShop.Models;

    public class ClosedAdViewModel : AdViewModel
    {
        public ClosedAdViewModel(Ad ad)
            : base(ad)
        {
            if (ad.ClosedOn != null) this.ClosedOn =  (DateTime) ad.ClosedOn;
        }

        public DateTime ClosedOn { get; set; }
    }
}
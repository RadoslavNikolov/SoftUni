namespace OnlineShop.Services.Models.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using OnlineShop.Models;

    public class AdViewModel
    {
        private ICollection<CategioryViewModel> categories;

        public AdViewModel()
        {
            
        }

        public AdViewModel(Ad ad)
        {
            this.Id = ad.Id;
            this.Name = ad.Name;
            this.Description = ad.Description;
            this.Price = ad.Price;
            this.Owner = new UserViewModel(ad.Owner);
            this.Type = ad.Type.Name;
            this.PostedOn = ad.PostedOn;
            this.Status = ad.Status.ToString();
            this.categories = new List<CategioryViewModel>();

            foreach (var category in ad.Categories)
            {
                this.categories.Add(new CategioryViewModel(category));
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public UserViewModel Owner { get; set; }

        public string Type { get; set; }

        public DateTime PostedOn { get; set; }

        public string Status { get; set; }

        public virtual IEnumerable<CategioryViewModel> Categories
        {
            get { return this.categories; }
            set { this.categories = (ICollection<CategioryViewModel>) value; }
        }

        public static Expression<Func<Ad, AdViewModel>> Create
        {
            get
            {
                return ad => new AdViewModel()
                {
                    Id = ad.Id,
                    Categories = ad.Categories
                    .Select(c => new CategioryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }),
                    Name = ad.Name,
                    Description = ad.Description,
                    Price = ad.Price,
                    Type = ad.Type.Name,
                    Owner = new UserViewModel
                    { UserName = ad.Owner.UserName},
                    PostedOn = ad.PostedOn
                };
            }
        } 
    }
}
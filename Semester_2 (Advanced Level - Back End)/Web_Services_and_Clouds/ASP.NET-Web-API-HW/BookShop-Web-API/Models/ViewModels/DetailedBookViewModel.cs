using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop_Web_API.Models.ViewModels
{
    using BookShopSystem.Models;

    public class DetailedBookViewModel
    {
        private ICollection<CategoryNameViewModel> categories;

        public DetailedBookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.Edition = Enum.GetName(typeof(EditionType), book.Edition);
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.ReleaseDate = book.ReleaseDate;
            this.AgeRestriction = Enum.GetName(typeof(AgeRestriction), book.AgeRestriction); ;
            this.Author = "" + book.Author.FirstName + " " + book.Author.LastName;
            this.AuthorId = book.Author.Id;
            this.categories = new List<CategoryNameViewModel>();

            foreach (var category in book.Categories)
            {
                this.categories.Add(new CategoryNameViewModel(category));
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Edition { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AgeRestriction { get; set; }

        public string Author { get; set; }

        public int AuthorId { get; set; }

        public virtual ICollection<CategoryNameViewModel> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
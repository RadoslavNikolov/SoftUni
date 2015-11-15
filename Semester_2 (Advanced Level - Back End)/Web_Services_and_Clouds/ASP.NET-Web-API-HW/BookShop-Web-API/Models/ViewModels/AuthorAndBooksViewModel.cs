namespace BookShop_Web_API.Models.ViewModels
{
    using System.Collections.Generic;
    using BookShopSystem.Models;

    public class AuthorAndBooksViewModel
    {
        private ICollection<BookViewModel> books;

        public AuthorAndBooksViewModel(Author author)
        {
            this.Id = author.Id;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
            this.books = new List<BookViewModel>();

            foreach (var book in author.Books)
            {
                this.books.Add(new BookViewModel(book));
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<BookViewModel> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
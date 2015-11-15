namespace BookShop_Web_API.Models.ViewModels
{
    using BookShopSystem.Models;

    public class BookViewModel
    {
        public BookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}
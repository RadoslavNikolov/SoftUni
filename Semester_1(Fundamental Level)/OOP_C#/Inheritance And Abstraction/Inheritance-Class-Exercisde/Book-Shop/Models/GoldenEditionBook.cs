namespace Book_Shop.Models
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) 
            : base(title, author, price)
        {
        }

        public override decimal Price => base.Price * 1.3m;
    }
}
namespace BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
        {
        }

        public override decimal Price
        {
            get
            {
                decimal newPrice = base.Price * (decimal) 1.3;
                return newPrice;
            }
            
        }
    }
}
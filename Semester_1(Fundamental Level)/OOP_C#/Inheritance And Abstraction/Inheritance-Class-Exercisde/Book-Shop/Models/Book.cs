namespace Book_Shop.Models
{
    using System;
    using System.Text;

    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Book title cannot be null or empty.");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Book author cannot be null or empty.");
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("-Type: {0}", this.GetType().Name));
            output.AppendLine(string.Format("-Title: {0}", this.Title));
            output.AppendLine(string.Format("-Author: {0}", this.Author));
            output.AppendLine(string.Format("-Price: {0}", this.Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)));

            return output.ToString();
        }
    }
}
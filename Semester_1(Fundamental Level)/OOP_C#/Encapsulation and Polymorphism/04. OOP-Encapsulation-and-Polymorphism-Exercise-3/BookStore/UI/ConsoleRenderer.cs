namespace BookStore.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class ConsoleRenderer : IRender
    {
        public void WriteLine(string toPrint)
        {
            Console.WriteLine(toPrint);
        }

        public void ListAll(List<IBook> booksInStock)
        {
            if (booksInStock.Any())
            {
                booksInStock.ForEach(b => WriteLine(b.Display()));                               
            }
            else
            {
                this.WriteLine("No books in stock");
            }
        }
    }
}
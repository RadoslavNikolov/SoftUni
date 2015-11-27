namespace BookStore.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Books;
    using Interfaces;

    public class BookStoreEngine
    {
        private readonly List<IBook> books;
        private decimal revenue;
        private readonly IRender renderer;
        private readonly IInputHandler inputHandler;

        public BookStoreEngine(IRender renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.IsRunning = true;
            this.books = new List<IBook>();
            this.revenue = 0;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            while (this.IsRunning)
            {
                string command = this.inputHandler.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }

                string[] commandArgs = command.Split();

                string commandResult = this.ExecuteCommand(commandArgs);

                this.renderer.WriteLine(commandResult);
            }

            this.renderer.WriteLine(String.Format("Total revenue: {0:F2}", this.revenue));
        }

        private string ExecuteCommand(string[] commandArgs)
        {
            switch (commandArgs[0].ToLower())
            {
                case "add":
                    return this.ExecuteAddBookCommand(commandArgs);
                case "sell":
                    return this.ExecuteSellBookCommand(commandArgs[1]);
                case "remove":
                    return this.ExecuteRemoveBookCommand(commandArgs[1]);
                case "listall": 
                    this.renderer.ListAll(this.books); return "";
                case "stop":
                    this.IsRunning = false;
                    return "Goodbye!";
                case "revenue" :
                    this.renderer.WriteLine(string.Format("{0:0.00}", this.revenue));
                    return "";
                default:
                    return "Unknown command";
            }
        }


        private string ExecuteRemoveBookCommand(string bookTitle)
        {
            IBook bookToRemove = this.books.FirstOrDefault(book => book.Title == bookTitle);

            if (bookToRemove == null)
            {
                return "Book does not exist";
            }

            this.books.Remove(bookToRemove);

            return "Book removed";
        }

        private string ExecuteSellBookCommand(string bookTitle)
        {
            IBook bookToSell = this.books.FirstOrDefault(book => book.Title == bookTitle);

            if (bookToSell == null)
            {
                return "Book does not exist";
            }

            this.books.Remove(bookToSell);
            this.revenue += bookToSell.Price;

            return "Book sold";
        }


        private string ExecuteAddBookCommand(string[] commandArgs)
        {
            string title = commandArgs[1];
            string author = commandArgs[2];
            decimal price = decimal.Parse(commandArgs[3], CultureInfo.InvariantCulture);

            this.books.Add(new Book(title, author, price));

            return "Book added";
        }
    }
}

namespace BookShop
{
    using System;

    public class TestClass
    {
        private static void Main(string[] args)
        {
            Book shogun = new Book("Action", "Unknown", 15);
            Console.WriteLine(shogun);
            GoldenEditionBook pipi = new GoldenEditionBook("Child", "Atrid Lindgren", 10);
            Console.WriteLine(pipi);
        }
    }
}
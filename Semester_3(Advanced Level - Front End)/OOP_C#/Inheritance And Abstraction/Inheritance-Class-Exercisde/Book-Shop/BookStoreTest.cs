namespace Book_Shop
{
    using System;
    using Models;

    class BookStoreTest
    {
        static void Main()
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.9m);
            Console.WriteLine(book);

            GoldenEditionBook goldenBook = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.9m);
            Console.WriteLine(goldenBook);
        }

    
    }
}

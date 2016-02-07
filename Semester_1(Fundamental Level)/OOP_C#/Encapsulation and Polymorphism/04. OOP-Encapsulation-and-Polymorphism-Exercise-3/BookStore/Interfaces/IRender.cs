namespace BookStore.Interfaces
{
    using System.Collections.Generic;

    public interface IRender
    {
        void WriteLine(string toPrint);

        void ListAll(List<IBook> booksInStock);
    }
    


         
}
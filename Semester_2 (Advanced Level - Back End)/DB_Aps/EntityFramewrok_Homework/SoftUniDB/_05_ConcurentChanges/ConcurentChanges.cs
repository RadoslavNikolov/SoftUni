namespace _05_ConcurentChanges
{
    using System;
    using System.Linq;
    using SuftuniContext;

    class ConcurentChanges
    {
        static void Main(string[] args)
        {
            var firstContext = new SuftuniContext();
            var secondContext = new SuftuniContext();

            var firstEmployee = firstContext.Employees.First();
            var secondEmployee = secondContext.Employees.First();

            firstEmployee.FirstName = "Petar";
            secondEmployee.FirstName = "Lazar";

            firstContext.SaveChanges();
            secondContext.SaveChanges();
            
            // Check final result
            var context = new SuftuniContext();
            Console.WriteLine(context.Employees.First().FirstName);

            /* To change Concurency Mode for column FirstName open DbContext.edmx, and in the data model 
             * designer, right-click the FirstName property in the Employees entity and then click Properties. 
             * In the Properties window, change the ConcurrencyMode property to Fixed.*/

            /* When Concurrency Mode is set to "None" the FirstName will be "Lazar" after both changes.
             * In other words Last write wins.
             * When the mode is set to "Fixed" the FirstName will be "Petar".
             * In other words the row is locked until the first context save the changes.*/
        }
        
    }
}

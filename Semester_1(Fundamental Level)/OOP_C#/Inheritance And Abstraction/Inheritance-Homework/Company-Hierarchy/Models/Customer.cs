namespace Company_Hierarchy.Models
{
    using System;
    using System.Linq;
    using Interrfaces;

    public class Customer : Person, ICustomer
    {
        private static int _id;

        public Customer(string firstName, string lastName) 
            : base(firstName, lastName)
        {
            Customer._id++;
            this.Id = Customer._id;
        }

        public int Id { get; private set; }

        public decimal PurchaseAmount()
        {
            var sales = CompanyDB.sales.Where(s => s.CustomerId == this.Id);
            var sum = sales.Sum(sale => sale.Products.Sum(p => p.Price));
            return sum;
        }

        public int GetNumberOfCustomesProducts()
        {
            return CompanyDB.sales.Where(s => s.CustomerId == this.Id)
                .Sum(sale => sale.Products.Count);
        }


        public override string ToString()
        {
            return String.Format(base.ToString() + " / Total spend amount: {0}  for {1} products", this.PurchaseAmount(), this.GetNumberOfCustomesProducts());
        }
    }
}
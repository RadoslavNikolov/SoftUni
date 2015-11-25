namespace Company_Hierarchy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interrfaces;

    public class Sale : ISale
    {
        private static int _id;
        private ICollection<IProduct> products;

        public Sale(int customerId, int salesManId)
        {
            Sale._id++;
            this.products = new HashSet<IProduct>();
            this.Id = Sale._id;
            this.CustomerId = customerId;
            this.SalesManID = salesManId;
        }

        public int Id { get; private set; }

        public int CustomerId { get; set; }

        public int SalesManID { get; set; }

        public virtual ICollection<IProduct> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public decimal GetSaleTotalPrice()
        {
            return this.products.Sum(p => p.Price);
        }

        public override string ToString()
        {
            var output = new StringBuilder();           
            output.AppendLine(String.Format("\nSale with Id: {0} has total price: {1}", this.Id, this.GetSaleTotalPrice()));
            this.products.ToList().ForEach(p => output.AppendLine("     " + p.ToString()));
            output.AppendLine(String.Format("Total amount of products: {0:N2}", this.GetSaleTotalPrice()));
            return output.ToString();
        }
    }
}
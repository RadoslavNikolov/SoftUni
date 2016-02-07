namespace Company_Hierarchy.Models
{
    using System;
    using Human_Worker_Student.Helpers;
    using Interrfaces;

    public class Product : IProduct
    {
        private static int _id = 0;
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            Product._id++;
            this.Name = name;
            this.Price = price;
            this.Id = Product._id;
        }

        public int Id { get; private set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                CustomValidators.ValidateName(value);
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                CustomValidators.ValidateNumber(value);
                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Type: {0} / Id: {1} / Name: {2} / Price: {3:N2}",
                this.GetType().Name,this.Id, this.Name, this.Price);
        }
    }
}
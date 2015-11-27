namespace Kurtovo_Konare_Bank.Models
{
    using System;

    public abstract class Customer
    {
        private string name;

        protected Customer(string firstName,  string address, string telephone = "No telephone")
        {
            this.Name = firstName;
            this.Address = address;
            this.Telephone = telephone;
            this.CreatedOn = DateTime.Now;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
namespace Kurtovo_Konare_Bank.Models
{
    using System;

    public abstract class Customer
    {
        private string name;

        protected Customer(string firstName,  string address)
        {
            this.Name = firstName;
            this.Address = address;
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

        public string Teleephone { get; set; }
    }
}
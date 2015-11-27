namespace Kurtovo_Konare_Bank.Models
{
    using System;

    public class IndividualCustomer : Customer
    {
        private double age;

        public IndividualCustomer(string firstName, string address, double age) 
            : base(firstName, address)
        {
            this.Age = age;
        }

        public double Age
        {
            get { return this.age; }
            private set
            {
                if (value < 18 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age must be in range [18 - 120]");
                }

                this.age = value;
            }
        }
    }
}
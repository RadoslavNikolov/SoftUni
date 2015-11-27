namespace Kurtovo_Konare_Bank.Models
{
    using System;

    public abstract class Account
    {
        private float interestRate;
        private decimal balance;

        protected Account(Customer customer, float interestRate, decimal balance = 0)
        {
            this.InterestRate = interestRate;
            this.Customer = customer;
            this.Balance = balance;
        }

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Balance cannot be null");
                }

                this.balance = value;
            }
        }

        public float InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < -5 || value > 25)
                {
                    throw new ArgumentOutOfRangeException("value", "Interest rate must be in range [-5 -- 25]");
                }

                this.interestRate = value;
            }
        }
    }
}
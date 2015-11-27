﻿namespace Kurtovo_Konare_Bank.Models
{
    using System;
    using Interfaces;

    public abstract class Account : IAccountable, IDepositable
    {
        private float interestRate;
        private decimal balance;

        protected Account(Customer customer, float interestRate, decimal balance = 0)
        {
            this.InterestRate = interestRate;
            this.Customer = customer;
            this.Balance = balance;
            this.CreatedOn = DateTime.Now;
        }

        public Customer Customer { get; set; }

        public DateTime CreatedOn { get; set; }

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

        public abstract decimal CalculateInterest(int months);

        public void DepositMoney(decimal amount)
        {
            CustomValidation.ValidateDepositAmount(amount);
            this.Balance += amount;
        }
    }
}
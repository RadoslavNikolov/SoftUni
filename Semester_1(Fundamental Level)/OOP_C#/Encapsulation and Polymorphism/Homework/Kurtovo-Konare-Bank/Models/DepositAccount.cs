namespace Kurtovo_Konare_Bank.Models
{
    using System;
    using Interfaces;

    public class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(Customer customer, float interestRate, decimal balance = 0) 
            : base(customer, interestRate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0m;

            if (this.Balance > 1000)
            {
                interest = this.Balance* (decimal)(((this.InterestRate/12.00)*months)/100.00);
            }

            this.Balance += interest;
            return interest;
        }

        public void WithdrawMoney(decimal amount)
        {
            CustomValidation.ValidateWithdramAmount(amount, this.Balance);
            this.Balance -= amount;
        }
    }
}
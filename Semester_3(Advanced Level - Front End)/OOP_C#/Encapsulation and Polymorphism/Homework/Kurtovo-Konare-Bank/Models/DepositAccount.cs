namespace Kurtovo_Konare_Bank.Models
{
    using System;
    using Interfaces;

    public class DepositAccount : Account, IDepositable, IWithdrawable
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
                interest = this.Balance*(1 + (interest*months/100.0m));
            }

            return interest;
        }

        public void WithdrawMoney(decimal amount)
        {
            CustomValidation.ValidateWithdramAmount(amount, this.Balance);
            this.Balance -= amount;
        }
    }
}
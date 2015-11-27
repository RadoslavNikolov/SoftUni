namespace Kurtovo_Konare_Bank.Models
{
    using System;
    using Interfaces;
    public class MortageAccount : Account, IDepositable
    {
        public MortageAccount(Customer customer, float interestRate, decimal balance = 0) 
            : base(customer, interestRate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            var fullRate = 0;
            var halfRate = 0;
            if (this.Customer.GetType().IsInstanceOfType(typeof (CompanyCustomer)))
            {
                fullRate = (months - 12) > 0 ? (months - 12) : 0;
                halfRate = (months - 12) < 0 ? months : 12;
            }
            else
            {
                fullRate = (months - 6) > 0 ? (months - 6) : 0;
            }
            

            decimal interestRate = this.Balance * (decimal)(1 + (this.InterestRate * (double)fullRate)/100.0) +
                                   this.Balance * (decimal)(1 + ((this.InterestRate/2.0) * halfRate)/100);

            return interestRate;
        }

    }
}
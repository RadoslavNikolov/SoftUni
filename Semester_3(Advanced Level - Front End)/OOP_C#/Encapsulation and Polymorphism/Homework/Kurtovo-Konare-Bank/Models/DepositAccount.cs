namespace Kurtovo_Konare_Bank.Models
{
    using Interfaces;

    public class DepositAccount : Account, IDepositable
    {
        public DepositAccount(Customer customer, float interestRate, decimal balance = 0) : base(customer, interestRate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            throw new System.NotImplementedException();
        }

        public void DepositMoney(decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
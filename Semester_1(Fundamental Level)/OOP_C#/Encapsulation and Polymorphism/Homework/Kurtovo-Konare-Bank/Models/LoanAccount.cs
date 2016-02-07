namespace Kurtovo_Konare_Bank.Models
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, float interestRate, decimal balance = 0) 
            : base(customer, interestRate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            var fullRate = 0;

            if (this.Customer.GetType().IsInstanceOfType(typeof(CompanyCustomer)))
            {
                fullRate = (months - 2) > 0 ? (months - 2) : 0;
            }
            else
            {
                fullRate = (months - 3) > 0 ? (months - 3) : 0;
            }

            decimal interestRate = this.Balance * (decimal)(((this.InterestRate/12.00) * fullRate)/100.0);
            this.Balance += interestRate;
                                 
            return interestRate;
        }

    }
}
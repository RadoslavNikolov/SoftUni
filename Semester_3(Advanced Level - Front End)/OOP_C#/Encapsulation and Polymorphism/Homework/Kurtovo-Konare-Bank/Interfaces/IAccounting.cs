namespace Kurtovo_Konare_Bank.Interfaces
{
    using Models;

    public interface IAccounting
    {
        string CalculateInterest(string accountCustomerName, int month);
        string DepositAmount(string accountCustomerName, decimal amount);
        string WithDrawAmount(string accountCustomerName, decimal amount);
        string PrintAccount(string accountCustomerName);
    }
}
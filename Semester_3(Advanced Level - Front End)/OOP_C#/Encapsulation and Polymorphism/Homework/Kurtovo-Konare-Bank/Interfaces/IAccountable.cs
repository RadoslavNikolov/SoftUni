namespace Kurtovo_Konare_Bank.Interfaces
{
    public interface IAccountable
    {
        decimal CalculateInterest(int months);
        void DepositMoney(decimal amount);
    }
}
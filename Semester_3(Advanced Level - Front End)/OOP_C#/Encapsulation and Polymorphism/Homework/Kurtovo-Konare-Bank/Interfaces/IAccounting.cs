namespace Kurtovo_Konare_Bank.Interfaces
{
    using Models;

    public interface IAccounting
    {
        string CalculateInterest(IAccountable account, int month);
        string DepositAmount(IDepositable account, decimal amount);
        string WithDrawAmount(IWithdrawable account, decimal amount);
    }
}
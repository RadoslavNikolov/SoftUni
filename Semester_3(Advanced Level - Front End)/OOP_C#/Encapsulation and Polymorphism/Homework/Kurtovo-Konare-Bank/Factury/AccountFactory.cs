namespace Kurtovo_Konare_Bank.Factury
{
    using System.Linq;
    using Models;

    public static class AccountFactory
    {
        internal static Account GetAccountByCistomerName(string customerName)
        {
            return BankDB.accounts.FirstOrDefault(a => a.Customer.Name == customerName);
        }
    }
}
namespace Kurtovo_Konare_Bank.Factury
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public static class AccountFactory
    {
        internal static Account GetAccountByCustomerName(string customerName)
        {
            return BankDB.accounts.FirstOrDefault(a => a.Customer.Name == customerName);
        }

        internal static IEnumerable<Account> GetAllAccountByCustomerName(string customerName)
        {
            return BankDB.accounts.Where(a => a.Customer.Name == customerName);
        }
    }
}
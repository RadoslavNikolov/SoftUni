namespace Kurtovo_Konare_Bank
{
    using System.Collections.Generic;
    using Models;

    public static class BankDB
    {
        public static IList<Customer> customers;
        public static IList<Account> accounts;

        static BankDB()
        {
            customers = new List<Customer>();
            accounts = new List<Account>();
        }
    }
}
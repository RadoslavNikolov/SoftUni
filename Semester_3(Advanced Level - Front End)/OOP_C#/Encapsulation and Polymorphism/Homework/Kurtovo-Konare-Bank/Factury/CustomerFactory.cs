namespace Kurtovo_Konare_Bank.Factury
{
    using System.Linq;
    using Models;

    public static class CustomerFactory
    {
        internal static Customer GetCustomerByName(string name)
        {
            return BankDB.customers.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
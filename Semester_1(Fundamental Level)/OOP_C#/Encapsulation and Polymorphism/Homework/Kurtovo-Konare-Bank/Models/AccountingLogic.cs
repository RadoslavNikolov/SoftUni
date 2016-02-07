namespace Kurtovo_Konare_Bank.Models
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Factury;
    using Interfaces;
    public class AccountingLogic : IAccounting
    {
        public string CalculateInterest(string accountCustomerName, int mounth)
        {
            IEnumerable<IAccountable> accounts = AccountFactory.GetAllAccountByCustomerName(accountCustomerName);
            try
            {
                var interest = accounts.Sum(account => account.CalculateInterest(mounth));

                return string.Format("{0:N3} interest rate was added to the balance of {1} account/s with customer name: {2}", interest, accounts.Count(), accountCustomerName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string DepositAmount(string accountCustomerName, decimal amount)
        {
            IAccountable account = AccountFactory.GetAccountByCustomerName(accountCustomerName);
            try
            {
                account.DepositMoney(amount);
                return "Deposit was successfull";
            }
            catch (ArgumentOutOfRangeException)
            {
                return "Deposit amount cannot be negative or zero";
            }
        }

        public string WithDrawAmount(string accountCustomerName, decimal amount)
        {
            IWithdrawable account = AccountFactory.GetAccountByCustomerName(accountCustomerName) as IWithdrawable;

            try
            {
                account.WithdrawMoney(amount);
                return "Withdraw was successfull";
            }
            catch (ArgumentOutOfRangeException)
            {
                return "There is not enough money in account balance";
            }
            catch (ArgumentException)
            {
                return "Cannot withdraw negative amount";
            }
        }

        public string PrintAccount(string accountCustomerName)
        {
            IEnumerable<IAccountable> accounts = AccountFactory.GetAllAccountByCustomerName(accountCustomerName);

            var output = new StringBuilder();
            try
            {


                foreach (var account in accounts)
                {
                    output.Append(account.ToString());
                }

                return output.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
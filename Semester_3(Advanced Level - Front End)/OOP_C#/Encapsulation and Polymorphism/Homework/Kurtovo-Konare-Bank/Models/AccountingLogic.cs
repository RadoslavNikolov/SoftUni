namespace Kurtovo_Konare_Bank.Models
{
    using System;
    using System.CodeDom;
    using Interfaces;
    public class AccountingLogic : IAccounting
    {
        public string CalculateInterest(IAccountable account, int mounth)
        {
            try
            {
                var interest = account.CalculateInterest(mounth);
                return string.Format("{0:N3} interest rate was added to the balance", interest);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string DepositAmount(IDepositable account, decimal amount)
        {
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

        public string WithDrawAmount(IWithdrawable account, decimal amount)
        {
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
    }
}
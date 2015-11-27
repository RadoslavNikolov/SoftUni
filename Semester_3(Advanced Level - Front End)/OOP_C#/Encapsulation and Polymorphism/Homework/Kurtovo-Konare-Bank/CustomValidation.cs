namespace Kurtovo_Konare_Bank
{
    using System;

    public static class CustomValidation
    {
        public static void ValidateDepositAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount cannot be negative or zero");
            }
        }

        public static void ValidateWithdramAmount(decimal amount, decimal balance)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw negative amount");
            }

            if (balance < amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "There is not enough money in account balance");
            }
        }
    }
}
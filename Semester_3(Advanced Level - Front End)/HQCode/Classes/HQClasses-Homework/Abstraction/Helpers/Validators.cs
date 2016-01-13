namespace Abstraction.Helpers
{
    using System;

    public static class Validators
    {
        public static void ValidateForNegativeNumber(double number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number", "Number cannot be zero or negative");
            }
        }
    }
}
namespace Methods.Helpers
{
    using System;
    using System.Collections;
    using Exceptions;

    public static class Validators
    {
        public static void ValidateForZeroOrNegativeNumber(double number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number", "Number cannot be zero or negative");
            }
        }

        public static void ValidateForPossibleTriangle(double a, double b, double c)
        {
            bool valid = true;

            if (a + b < c)
            {
                valid = false;
            }

            if (a + c < b)
            {
                valid = false;
            }

            if (b + c < a)
            {
                valid = false;
            }

            if (!valid)
            {
                throw new ArgumentException("There is no possible triangle with passed arguments as triangle sides");
            }
        }

        public static void ValidateForDigit(int digit)
        {
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException("digit", "Digit must be in range [0 - 9]");
            }
        }

        public static void ValidateForEmptyCollection(ICollection collection)
        {
            if (collection == null || collection.Count == 0)
            {
                throw new InitializationException("Collection is null or empty");
            }
        }

        public static void ValidateForValidNumber(object number)
        {        
            bool success = false;

            double result = 0;
            success = double.TryParse(number.ToString(), out result);

            if (!success)
            {
                var result1 = 0m;
                success = decimal.TryParse(number.ToString(), out result1);
            }

            if (!success)
            {
                throw new InvalidNumberException("Passed argument is not valid number");
            }
        }
    }
}
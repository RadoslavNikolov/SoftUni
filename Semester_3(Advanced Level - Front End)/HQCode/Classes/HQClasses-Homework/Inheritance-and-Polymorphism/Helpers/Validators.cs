namespace InheritanceAndPolymorphism.Helpers
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

        public static void ValidateForEmptyString(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("String cannot be null or empty");
            }
        }
    }
}
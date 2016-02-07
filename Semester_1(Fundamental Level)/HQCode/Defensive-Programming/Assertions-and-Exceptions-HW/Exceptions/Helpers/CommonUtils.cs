namespace Exceptions_Homework.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Exceptions;

    public static class CommonUtils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            Validators.Validators.ValidateArray(arr);

            if (startIndex < 0)
            {
                throw new NegativeNumberException("Start index cannot be negative");
            }

            if (startIndex + count >= arr.Length)
            {
                throw new ArgumentException("Count is out of range");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentException("Invalid count!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("There is no negatibe prime numbers");
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    throw new NotPrimeException(string.Format("The {0} is not prime!", number));
                }
            }
        }
    }
}
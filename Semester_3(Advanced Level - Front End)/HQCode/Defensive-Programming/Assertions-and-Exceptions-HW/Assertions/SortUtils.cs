namespace Assertions_Homework
{
    using System;
    using System.Linq;

    public static class SortUtils
    {
        public static bool IsArraySorted<T>(T[] numbers)
        {
            T[] sorted = new T[numbers.Length];
            Array.Copy(numbers, sorted, numbers.Length);

            var isEqual = numbers.SequenceEqual(sorted);

            return isEqual;
        }

    }
}
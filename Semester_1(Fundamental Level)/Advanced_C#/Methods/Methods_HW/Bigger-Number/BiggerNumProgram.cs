namespace Bigger_Number
{
    using System;

    public static class BiggerNumProgram
    {
        public static void Main()
        {
            Console.Write("Enter first integer number: ");
            var num1 = int.Parse(Console.ReadLine().Trim());

            Console.Write("Enter second integer number: ");
            var num2 = int.Parse(Console.ReadLine().Trim());

            int max = GetMax(num1, num2);
            int max1 = num1.Max(num2);

            Console.WriteLine(max);
            Console.WriteLine(max1);
        }

        public static T GetMax<T>(T item1, T item2)
            where T : IComparable<T>
        {
            if (item1.CompareTo(item2) >= 0)
            {
                return item1;
            }

            return item2;
        }

        //extension method
        public static T Max<T>(this T item1, T item2)
           where T : IComparable<T>
        {
            if (item1.CompareTo(item2) >= 0)
            {
                return item1;
            }

            return item2;
        }
    }
}

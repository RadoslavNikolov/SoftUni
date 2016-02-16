using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Calculations
{
    public static class NumCalculationsProgram
    {
        public static void Main()
        {
            int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };

            Console.WriteLine(sequenceOne.GetMaxLinq());
            Console.WriteLine(sequenceOne.GetMinLinq());
            Console.WriteLine(sequenceOne.GetSumLinq());
            Console.WriteLine(sequenceOne.GetAverageLinq());
            Console.WriteLine("=====================");
            Console.WriteLine(sequenceOne.GetMax());
            Console.WriteLine(sequenceOne.GetMin());
            Console.WriteLine(sequenceOne.GetSum());
            Console.WriteLine(sequenceOne.GetAverage());
        }

#region " Using LINQ"
        public static T GetMaxLinq<T>(this IEnumerable<T> set)
            where T : IComparable<T>
        {
            return set.Max();
        }

        public static T GetMinLinq<T>(this IEnumerable<T> set)
           where T : IComparable<T>
        {
            return set.Min();
        }

        public static T GetSumLinq<T>(this IEnumerable<T> set)
        {
            T total = default(T);

            return set.Cast<dynamic>().Aggregate(total, (current, item) => current + item);
        }

        public static double GetAverageLinq<T>(this IEnumerable<T> set)
        {
            T total = default(T);

            total = set.Cast<dynamic>().Aggregate(total, (current, item) => current + item);

            return (dynamic)total / (double)set.Count();
        }
#endregion

#region " Not using LINQ"
        public static T GetMax<T>(this IEnumerable<T> set)
           where T : struct, IComparable<T>
        {
            T maxValue = MinValue((dynamic)set.First());

            foreach (dynamic item in set)
            {
                if (item > maxValue)
                {
                    maxValue = item;
                }
            }

            return maxValue;
        }

        public static T GetMin<T>(this IEnumerable<T> set)
           where T : IComparable<T>
        {
            T minValue = MaxValue((dynamic)set.First());

            foreach (dynamic item in set)
            {
                if (item < minValue)
                {
                    minValue = item;
                }
            }
            return minValue;
        }

        public static T GetSum<T>(this IEnumerable<T> set)
        {
            T total = default(T);

            foreach (dynamic item in set)
            {
                total = total + item;
            }

            return total;
        }

        public static double GetAverage<T>(this IEnumerable<T> set)
        {
            T total = default(T);

            foreach (dynamic item in set)
            {
                total = total + item;
            }

            return (dynamic)total / (double)set.Count();
        }
#endregion


#region " Get Min and Max value of dynamic type"
        public static int MaxValue(int value)
        {
            return int.MaxValue;
        }

        public static double MaxValue(double value)
        {
            return double.MaxValue;
        }

        public static byte MaxValue(byte value)
        {
            return byte.MaxValue;
        }

        public static float MaxValue(float value)
        {
            return float.MaxValue;
        }

        public static decimal MaxValue(decimal value)
        {
            return decimal.MaxValue;
        }



        public static int MinValue(int value)
        {
            return int.MinValue;
        }

        public static double MinValue(double value)
        {
            return double.MinValue;
        }

        public static byte MinValue(byte value)
        {
            return byte.MinValue;
        }

        public static float MinValue(float value)
        {
            return float.MinValue;
        }

        public static decimal MinValue(decimal value)
        {
            return decimal.MinValue;
        }
#endregion
    }
}

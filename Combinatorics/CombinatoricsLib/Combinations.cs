namespace CombinatoricsLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Combinations
    {
        /// <summary>
        /// Gets the k combs with repetition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="length">The length.</param>
        /// <returns>Returns an enumeration of enumerators, one for each combination of the input with deffined length.</returns>
        public static IEnumerable<IEnumerable<T>> GetKCombsWithRepetition<T>(IEnumerable<T> list, int length) 
            where T : IComparable
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetKCombsWithRepetition(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// Gets the k combs without repetition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="length">The length.</param>
        /// <returns>Returns an enumeration of enumerators, one for each combination of the input with deffined length.</returns>
        public static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length)
            where T : IComparable
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }


        /// <summary>
        /// Generates the combinations without using strings.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList">The input list.</param>
        /// <returns>Returns an enumeration of enumerators, one for each combination of the input. </returns>
        public static IEnumerable<IEnumerable<T>> GetCombinationsUsingBitMask<T>(IList<T> inputList)
        {
            var maskNumber = (int)Math.Pow(2, inputList.Count());
            var result = AllCombinations(inputList, maskNumber);

            return result;
        }

        private static IEnumerable<IEnumerable<T>> AllCombinations<T>(IList<T> inputList, int maskNumber)
        {
            var allCombinationslist = new List<IList<T>>();
            for (int num = 1; num < maskNumber; num++)
            {
                var numbersPrecision = Convert.ToString(num, 2).Length;

                var currentCombinations = new List<T>();
                for (int i = 0; i < numbersPrecision; i++)
                {
                    if ((num & (1 << i)) == 1 << i)
                    {
                        currentCombinations.Add(inputList[inputList.Count - 1 - i]);
                    }
                }

                if (currentCombinations.Any())
                {
                    allCombinationslist.Add(currentCombinations);
                }
            }

            return allCombinationslist;
        }

        /// <summary>
        /// Gets the combinations using string mask.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList">The input list.</param>
        /// <returns>Returns an enumeration of enumerators, one for each combination of the input. </returns>
        public static IEnumerable<IEnumerable<T>> GetCombinationsUsingStringMask<T>(IList<T> inputList)
        {
            var allLists = new List<IList<T>>();
            double count = Math.Pow(2, inputList.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                var currList = new List<T>();
                string str = Convert.ToString(i, 2).PadLeft(inputList.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        currList.Add(inputList[j]);
                    }
                }
                allLists.Add(currList);
            }

            return allLists;
        }
    }
}
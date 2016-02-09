namespace SubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CombinationUtils
    {
        // Returns an enumeration of enumerators, one for each combination of the input.
        public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(IList<T> inputList)
        {
            var maskNumber = (int)Math.Pow(2, inputList.Count());
            var result = GetCombinations(inputList, maskNumber);
            
            return result;
        }

        private static IEnumerable<IEnumerable<T>> GetCombinations<T>(IList<T> inputList, int maskNumber)
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
    }
}
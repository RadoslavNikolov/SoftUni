namespace ClassExercise
{
    using System;
    using System.Collections.Generic;

    public static class Sorters<T> where T : IComparable
    {
        public static T[] BubbleSort(T[] arrayToSort, bool descendant = false)
        {
            BubbleSort(arrayToSort, Comparer<T>.Default, descendant);

            return arrayToSort;
        }

        private static void BubbleSort<T>(T[] array, IComparer<T> comaprer, bool descendant)
        {
            bool stillSorting = true;

            while (stillSorting)
            {
                stillSorting = false;
                for (int i = 0; i < array.Length-1; i++)
                {
                    T x = array[i];
                    T y = array[i + 1];

                    if (descendant)
                    {
                        if (comaprer.Compare(x, y) < 0)
                        {
                            array[i] = y;
                            array[i + 1] = x;
                            stillSorting = true;
                        }
                    }
                    else
                    {
                        if (comaprer.Compare(x, y) > 0)
                        {
                            array[i] = y;
                            array[i + 1] = x;
                            stillSorting = true;
                        }
                    }              
                }
            }
        }
    }   
}
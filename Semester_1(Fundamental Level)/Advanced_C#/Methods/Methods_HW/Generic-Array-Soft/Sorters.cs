namespace Generic_Array_Soft
{
    using System;
    using System.Collections.Generic;

    public static class Sorters<T> 
        where T : IComparable<T>
    {
        public static T[] BubbleSort(T[] arrayToSort, bool descendant = false)
        {
            BubbleSort(arrayToSort, Comparer<T>.Default, descendant);

            return arrayToSort;
        }

        public static T[] SelectionSort(T[] arrayToSort, bool descendant = false)
        {
            SelectionSort(arrayToSort, Comparer<T>.Default, descendant);

            return arrayToSort;
        }

        private static void BubbleSort<T>(T[] array, IComparer<T> comaprer, bool descendant)
        {
            bool stillSorting = true;

            while (stillSorting)
            {
                stillSorting = false;
                for (int i = 0; i < array.Length - 1; i++)
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

        private static void SelectionSort<T>(T[] array, IComparer<T> comaprer, bool descendant)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var posMin = i;

                for (int j = i + 1; j < array.Length; j++)
                {

                    if (descendant)
                    {
                        if (comaprer.Compare(array[j], array[posMin]) > 0)
                        {
                            posMin = j;
                        }
                    }
                    else
                    {
                        if (comaprer.Compare(array[j], array[posMin]) < 0)
                        {
                            posMin = j;
                        }
                    }

                    if (posMin != i)
                    {
                        var temp = array[i];
                        array[i] = array[posMin];
                        array[posMin] = temp;
                    }
                }
            }
        } 
    }
}
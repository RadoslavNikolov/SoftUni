namespace DefProgramming_Class_Exercise
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class SortUtils
    {
        public static void QuickSort_Recursive(int [] arr, int left = 0, int right = 0)
        {
            Debug.Assert(arr != null && arr.Length > 0, "Sorting array is not initialized or empty!");

            if (right == 0)
            {
                right = arr.Length - 1;
            }

            // For Recusrion
            if(left < right)
            {
                int pivot = Partition(arr, left, right);
 
                if(pivot > 1)
                    QuickSort_Recursive(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort_Recursive(arr, pivot + 1, right);
            }
        }


        private static int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public static bool IsArraySorted<T>(T[] numbers)
        {
            //Shallow copy of the array
            //int[] sorted = (int[]) numbers.Clone();

            //Deap copy of the array
            T[] sorted = new T[numbers.Length];
            Array.Copy(numbers, sorted, numbers.Length);

            var isEqual = numbers.SequenceEqual(sorted);

            return isEqual;
        }
    }
}
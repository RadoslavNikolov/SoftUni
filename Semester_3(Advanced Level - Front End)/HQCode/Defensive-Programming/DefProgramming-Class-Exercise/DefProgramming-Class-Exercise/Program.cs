using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefProgramming_Class_Exercise
{
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            int[] numbersArr = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;

            Console.WriteLine("QuickSort By Recursive Method");
            SortUtils.QuickSort_Recursive(numbersArr, 0, len - 1);

            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbersArr[i]);

            Console.WriteLine();

            int[] numbersArr2 = null;
            //Console.WriteLine("QuickSort By Recursive Method on empty or not initialized array");
            //SortUtils.QuickSort_Recursive(numbersArr2);

            numbersArr2 = new int[0];
            //Console.WriteLine("QuickSort By Recursive Method on empty or not initialized array");
            //SortUtils.QuickSort_Recursive(numbersArr2);

            //Post condition
            Debug.Assert(SortUtils.IsArraySorted(numbersArr), "Array was not sorted");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricsTests
{
    using System.Security.Cryptography;
    using CombinatoricsLib;


    class Program
    {
        //static void Main(string[] args)
        //{

        //    var inputList = new List<string>() { "a", "b", "c" };
        //    var result = Permutations.GetPermutationsWithoutRepetition(inputList, 3);

        //    PrintResult(result);
        //}

        //private static void PrintResult(IEnumerable<IEnumerable<string>> result)
        //{
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(string.Join(", ", item));
        //    }
        //}


        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4};

            ////Permutations
            //var result = Permutations.GetPermutations(list, 3);        
            //PrintResult(result);
            //Console.WriteLine("====================");
            //var result = Permutations.GetPermutationsWithRepetition(list, 3);
            //PrintResult(result);

            //var intList = new List<int>() {1, 2, 3, 4, 5};

            //var result = Combinations.GetKCombs(intList, 3);
            //PrintResult(result);
            //Console.WriteLine("====================");
            //var result1 = Combinations.GetKCombsWithRepetition(intList, 3);
            //PrintResult(result1);


            int n = 3;
            int k = 2;

            var intList = new List<int>() { 1, 2, 3, 4, 5 };
            var takenArr = new int[3];
            var used = new bool[intList.Count + 1];


            GenerateVariations(intList, takenArr, used);


        }

        private static void GenerateVariations<T>(IList<T> list,  IList<T> arr, IList<bool> used, int index = 0)
        {
            if (index >= arr.Count)
            {
                Print(arr);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!used[i])
                    {
                        arr[index] = list[i];
                        used[i] = true;
                        GenerateVariations(list, arr, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }


        private static void Print(int index, List<int> list)
        {

            for (int i = 0; i < index; i++)
            {
                Console.Write("{0} ", list[i+1]);
            }
            Console.WriteLine();
        }


        private static void Print<T>(IList<T> arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }

        private static void PrintResult<T>(IEnumerable<IEnumerable<T>> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }


    }
}

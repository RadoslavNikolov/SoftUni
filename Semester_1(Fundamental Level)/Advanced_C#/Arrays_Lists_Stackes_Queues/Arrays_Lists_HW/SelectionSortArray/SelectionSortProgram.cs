namespace SelectionSortArray
{
    using System;
    using System.Linq;
    using Utils;

    public class SelectionSortProgram
    {
        public static void Main()
        {
            const string exitCommand = "exit";

            Console.Write("Enter array of integr numbers, separated by comma or \"{0}\" for exiting the program: ", exitCommand);
            while (true)
            {
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                var inputStringArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //using LINQ with delegeate
                int[] intArray = inputStringArray.Select(int.Parse).ToArray();

                ////Bubble sort ascending
                //Sorters<int>.BubbleSort(intArray);
                ////Bubble sort descending
                //Sorters<int>.BubbleSort(intArray, true);

                ////Selection sort ascending
                Sorters<int>.SelectionSort(intArray);
                ////Selection sort descending
                //Sorters<int>.SelectionSort(intArray, true);

                Console.WriteLine("Sorted array is: {0}", string.Join(", ", intArray));
            }
        }
    }
}

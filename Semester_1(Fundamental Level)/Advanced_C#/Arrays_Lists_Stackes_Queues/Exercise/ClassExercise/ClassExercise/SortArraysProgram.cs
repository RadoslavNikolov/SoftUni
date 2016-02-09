namespace ClassExercise
{
    using System;
    using System.Linq;

    class SortArraysProgram
    {
        static void Main()
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

                var inputStringArray = inputLine.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                //using LINQ with delegeate
                int[] intArray = inputStringArray.Select(int.Parse).ToArray();

                //Sorters<int>.BubbleSort(intArray);
                Sorters<int>.BubbleSort(intArray, true);


                Console.WriteLine("Sorted array is: {0}", string.Join(", ", intArray));
            }
        }
    }
}

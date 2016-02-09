namespace SortArrayOfNumbers
{
    using System;
    using System.Linq;

    public class SortArrayProgram
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
                //using LINQ with delegete
                int[] intArray = inputStringArray.Select(int.Parse).ToArray();

                Array.Sort(intArray);

                Console.WriteLine("Sorted array is: {0}", string.Join(", ", intArray));
            }
        }
    }
}

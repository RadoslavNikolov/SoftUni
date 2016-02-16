namespace Generic_Array_Soft
{
    using System;

    public class GenricArraySortProgram
    {
        public static void Main()
        {
            int[] intSequence = { 1, 3, 4, 5, 1, 0, 5 };
            string[] stringSequence = { "zaz", "cba", "baa", "azis"};
            DateTime[] datetimeSequence =
            {
                new DateTime(2002, 3, 1),
                new DateTime(2015, 5, 6),
                new DateTime(2014, 1, 1)
            };

            Sorters<int>.BubbleSort(intSequence);
            Console.WriteLine(string.Join(", ", intSequence));
            Sorters<int>.BubbleSort(intSequence, true);
            Console.WriteLine(string.Join(", ", intSequence));

            Sorters<string>.SelectionSort(stringSequence);
            Console.WriteLine(string.Join(", ", stringSequence));
            Sorters<string>.SelectionSort(stringSequence, true);
            Console.WriteLine(string.Join(", ", stringSequence));

            Sorters<DateTime>.BubbleSort(datetimeSequence);
            Console.WriteLine(string.Join(", ", datetimeSequence));
            Sorters<DateTime>.SelectionSort(datetimeSequence, true);
            Console.WriteLine(string.Join(", ", datetimeSequence));

        }
    }
}

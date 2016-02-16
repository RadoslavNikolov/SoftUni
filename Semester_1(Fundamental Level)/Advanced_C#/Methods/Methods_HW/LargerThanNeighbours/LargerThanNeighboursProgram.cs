namespace LargerThanNeighbours
{
    using System;

    class LargerThanNeighboursProgram
    {
        static void Main()
        {
            int[] numbers = {1, 3, 4, 5, 1, 0, 5};

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNieghbours(numbers, i));
            }
        }

        private static bool IsLargerThanNieghbours(int[] numbers, int i)
        {
            var isLarger = false;

            if (i == 0 && numbers.Length > 1)
            {
                if (numbers[i] > numbers[i+1])
                {
                    isLarger = true;
                }
            }

            if (i == 0 && numbers.Length == 1)
            {
                isLarger = true;
            }

            if (i > 0 && i < numbers.Length - 1)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                {
                    isLarger = true;
                }
            }

            if (i == numbers.Length - 1)
            {
                if (numbers[i] > numbers[i-1])
                {
                    isLarger = true;
                }
            }

            return isLarger;
        }
    }
}

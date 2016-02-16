namespace First_Larger_Than_Neighbours
{
    using System;

    public static class FirstLargerThanNeighProgram
    {
        public static void Main()
        {
            int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
            int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
            int[] sequenceThree = { 1, 1, 1};

            var seqList = new[]
            {
                sequenceOne, sequenceTwo, sequenceThree
            };

            foreach (var sequence in seqList)
            {
                int index = -1;

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (IsLargerThanNieghbours(sequence, i))
                    {
                        index = i;
                        break;
                    }
                }

                Console.WriteLine(index);
            }
        }

        private static bool IsLargerThanNieghbours(int[] numbers, int i)
        {
            var isLarger = false;

            if (i == 0 && numbers.Length > 1)
            {
                if (numbers[i] > numbers[i + 1])
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
                if (numbers[i] > numbers[i - 1])
                {
                    isLarger = true;
                }
            }

            return isLarger;
        }
    }
}

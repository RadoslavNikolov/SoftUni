namespace Dompare_Sortig_Algorithms.Sorters
{
    using System.Collections.Generic;

    public class QuickSorter : SorterAbstract
    {
        private static int Partition(ref int[] inputArray, int left, int right)
        {
            int x = inputArray[right];
            int i = (left - 1);

            for (int j = left; j <= right - 1; ++j)
            {
                if (inputArray[j] <= x)
                {
                    ++i;
                    Swap(ref inputArray[i], ref inputArray[j]);
                }
            }

            Swap(ref inputArray[i + 1], ref inputArray[right]);

            return (i + 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public override void Sort(int[] inputArray)
        {
            int startIndex = 0;
            int endIndex = inputArray.Length - 1;
            int top = -1;
            int[] stack = new int[inputArray.Length];

            stack[++top] = startIndex;
            stack[++top] = endIndex;

            while (top >= 0)
            {
                endIndex = stack[top--];
                startIndex = stack[top--];

                int p = Partition(ref inputArray, startIndex, endIndex);

                if (p - 1 > startIndex)
                {
                    stack[++top] = startIndex;
                    stack[++top] = p - 1;
                }

                if (p + 1 < endIndex)
                {
                    stack[++top] = p + 1;
                    stack[++top] = endIndex;
                }
            }
        }
    }
}
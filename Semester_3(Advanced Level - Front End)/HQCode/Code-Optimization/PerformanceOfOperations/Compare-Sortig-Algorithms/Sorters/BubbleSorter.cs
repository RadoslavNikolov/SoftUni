namespace Dompare_Sortig_Algorithms.Sorters
{
    public class BubbleSorter : SorterAbstract
    {
        public override void Sort(int[] inputArray)
        {
            for (int i = inputArray.Length - 1; i > 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (inputArray[j] > inputArray[j + 1])
                    {
                        int highValue = inputArray[j];

                        inputArray[j] = inputArray[j + 1];
                        inputArray[j + 1] = highValue;
                    }
                }
            }
        }
    }
}
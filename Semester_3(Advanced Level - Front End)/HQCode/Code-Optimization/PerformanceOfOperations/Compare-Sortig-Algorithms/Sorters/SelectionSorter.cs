namespace Dompare_Sortig_Algorithms.Sorters
{
    public class SelectionSorter : SorterAbstract
    {
        public override void Sort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                var posMin = i;

                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[posMin])
                    {
                        posMin = j;
                    }
                }

                if (posMin != i)
                {
                    var temp = inputArray[i];
                    inputArray[i] = inputArray[posMin];
                    inputArray[posMin] = temp;
                }
            }
        }
    }
}
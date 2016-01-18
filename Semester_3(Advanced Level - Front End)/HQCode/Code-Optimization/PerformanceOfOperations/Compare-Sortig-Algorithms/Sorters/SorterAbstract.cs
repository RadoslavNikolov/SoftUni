namespace Dompare_Sortig_Algorithms.Sorters
{
    using System.Collections.Generic;
    using Interfaces;
    public abstract class SorterAbstract : ISorter
    {
        public abstract void Sort(int[] inputArray);
    }
}
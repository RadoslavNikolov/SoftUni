namespace Dompare_Sortig_Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Interfaces;
    public class MeasureObject : IMeasurable
    {
        private ISorter sorter;
        private IList<int> numbersCollection;
        private long sortingTime = 0;

        public MeasureObject(ISorter sorter, int targetCountOfNumbers = 0)
        {
            this.Sorter = sorter;
            this.numbersCollection = new List<int>();

            if (targetCountOfNumbers > 0)
            {
                this.FillNumbersCollection(targetCountOfNumbers);
            }
        }

        public ISorter Sorter
        {
            get { return this.sorter; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Sorter cannot be null");
                }
                this.sorter = value;
            }
        }

        public long GetSortingTime()
        {
            return this.sortingTime;
        }

        public void FillNumbersCollection(int targetCount)
        {
            var random = new Random();
            this.numbersCollection = new List<int>();

            while (this.numbersCollection.Count < targetCount)
            {
                this.numbersCollection.Add(random.Next());
            }
        }

        public void MeasurePerformance()
        {
            int[] numbersToSort = this.GetDeapCopy(this.numbersCollection).ToArray();
            Stopwatch timer = new Stopwatch();

            timer.Start();
            this.sorter.Sort(numbersToSort);
            timer.Stop();
            this.sortingTime = timer.ElapsedMilliseconds;
        }

        private int[] GetDeapCopy(IList<int> sourceList)
        {
            int[] numberArray = new int[sourceList.Count];

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = sourceList[i];
            }

            return numberArray;
        }
    }
}
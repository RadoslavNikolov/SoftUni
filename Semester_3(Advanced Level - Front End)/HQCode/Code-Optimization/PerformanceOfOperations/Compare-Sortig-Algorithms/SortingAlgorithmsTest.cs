using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dompare_Sortig_Algorithms
{
    using Sorters;

    class SortingAlgorithmsTest
    {
        static void Main()
        {
            List<int> countOfNumers = new List<int>()
            {
                2,
                10,
                50,
                100,
                1000,
                10000,
                //100000,
                //1000000,
                //10000000
            };

            string headerRow = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|",
               "Method".PadRight(12),
               "    n=10 ms".PadRight(18),
               "    n=50 ms".PadRight(18),
               "    n=100 ms".PadRight(18),
               "    n=1000 ms".PadRight(18),
               "    n=10000 ms".PadRight(18),
               "    n=100000 ms".PadRight(18),
               "    n=1000000 ms".PadRight(18),
               "    n=10000000 ms".PadRight(18)
               );
            FileUtils.AppendLineInFile(headerRow);


            var sortingAlgorithm = new BubbleSorter();
            var measureObject = new MeasureObject(sortingAlgorithm);

            //Bubble sort measurement
            StringBuilder outputLine = new StringBuilder(string.Format("{0}|", "Bubble".PadRight(12)));
            foreach (var countOfNumer in countOfNumers)
            {
                measureObject.FillNumbersCollection(countOfNumer);
                measureObject.MeasurePerformance();
                var result = measureObject.GetSortingTime();
                if (countOfNumer > 2)
                {
                    outputLine.Append(string.Format("{0}|", result == 0 ? "<0".PadRight(18) : result.ToString().PadRight(18)));
                }
            }
            FileUtils.AppendLineInFile(outputLine.ToString());

            //Insertion sort measurement
            measureObject.Sorter = new InsertionSorter();
            outputLine = new StringBuilder(string.Format("{0}|", "Insertion".PadRight(12)));
            foreach (var countOfNumer in countOfNumers)
            {
                measureObject.FillNumbersCollection(countOfNumer);
                measureObject.MeasurePerformance();
                var result = measureObject.GetSortingTime();
                if (countOfNumer > 2)
                {
                    outputLine.Append(string.Format("{0}|", result == 0 ? "<0".PadRight(18) : result.ToString().PadRight(18)));
                }
            }
            FileUtils.AppendLineInFile(outputLine.ToString());

            //Selection sort measurement
            measureObject.Sorter = new SelectionSorter();
            outputLine = new StringBuilder(string.Format("{0}|", "Selection".PadRight(12)));
            foreach (var countOfNumer in countOfNumers)
            {
                measureObject.FillNumbersCollection(countOfNumer);
                measureObject.MeasurePerformance();
                var result = measureObject.GetSortingTime();
                if (countOfNumer > 2)
                {
                    outputLine.Append(string.Format("{0}|", result == 0 ? "<0".PadRight(18) : result.ToString().PadRight(18)));
                }
            }
            FileUtils.AppendLineInFile(outputLine.ToString());

            //Merge sort measurement
            measureObject.Sorter = new MergeSorter();
            outputLine = new StringBuilder(string.Format("{0}|", "Merge".PadRight(12)));
            foreach (var countOfNumer in countOfNumers)
            {
                measureObject.FillNumbersCollection(countOfNumer);
                measureObject.MeasurePerformance();
                var result = measureObject.GetSortingTime();
                if (countOfNumer > 2)
                {
                    outputLine.Append(string.Format("{0}|", result == 0 ? "<0".PadRight(18) : result.ToString().PadRight(18)));
                }
            }
            FileUtils.AppendLineInFile(outputLine.ToString());


            //Quick sort measurement
            measureObject.Sorter = new QuickSorter();
            outputLine = new StringBuilder(string.Format("{0}|", "Quick".PadRight(12)));
            foreach (var countOfNumer in countOfNumers)
            {
                measureObject.FillNumbersCollection(countOfNumer);
                measureObject.MeasurePerformance();
                var result = measureObject.GetSortingTime();
                if (countOfNumer > 2)
                {
                    outputLine.Append(string.Format("{0}|", result == 0 ? "<0".PadRight(18) : result.ToString().PadRight(18)));
                }
            }
            FileUtils.AppendLineInFile(outputLine.ToString());
        }
    }
}

namespace Dompare_Sortig_Algorithms.Sorters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter : SorterAbstract
    {
        private int[] Merge(ref int[] left, ref int[] right)
        {
            List<int> leftList = left.OfType<int>().ToList();
            List<int> rightList = right.OfType<int>().ToList();
            List<int> resultList = new List<int>();


            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList[0] <= rightList[0])
                    {
                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }

                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }

                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }

                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            int[] result = resultList.ToArray();
            return result;
        }

        private int[] MergeSort(ref int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middleIndex = (array.Length) / 2;
            int[] left = new int[middleIndex];
            int[] right = new int[array.Length - middleIndex];

            Array.Copy(array, left, middleIndex);
            Array.Copy(array, middleIndex, right, 0, right.Length);

            left = this.MergeSort(ref left);
            right = this.MergeSort(ref right);

            return this.Merge(ref left,ref right);
        }

        public override void Sort(int[] inputArray)
        {
            this.MergeSort(ref inputArray);
        }
    }
}
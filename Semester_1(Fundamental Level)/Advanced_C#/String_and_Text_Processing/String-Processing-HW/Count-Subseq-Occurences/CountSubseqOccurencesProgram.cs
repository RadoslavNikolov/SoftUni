using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Subseq_Occurences
{
    public class CountSubseqOccurencesProgram
    {
        public static void Main()
        {
            Console.Write("Enter string to check: ");
            var inputString = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter sarching subsequence: ");
            var searchedString = Console.ReadLine().Trim().ToLower();

            char[] searchedArray = searchedString.ToCharArray();
            char[] sourceArray = inputString.ToCharArray();

            var result = -1;
            var countOfOccurence = 0;

            //do
            //{
            //    //Knuth–Morris–Pratt algorithm. Do not overlap strings.
            //    StringSearcher stringSearcher = new StringSearcher(searchedArray);
            //    result = stringSearcher.Search(sourceArray);

            //    if (result >= 0)
            //    {
            //        for (int i = 0; i < searchedString.Length; i++)
            //        {
            //            sourceArray[result + i] = ' ';
            //        }

            //        countOfOccurence++;
            //        Console.WriteLine("Location of \"{0}\" in the input strinf is at: {1}", searchedString, result);
            //    }    
                
            //} while (result >= 0);


            for (int i = 0; i <= inputString.Length - searchedString.Length; i++)
            {
                result = CheckForOccurence(inputString, searchedString, i);
                if (result >= 0)
                {
                    countOfOccurence++;
                    Console.WriteLine("Location of \"{0}\" in the input strinf is at: {1}", searchedString, result);
                }
            }

            Console.WriteLine("Count of occurences of \"{0}\":  {1}", searchedString, countOfOccurence);
        }

        private static int CheckForOccurence(string inputString, string searchedString, int index)
        {
            if (inputString.Substring(index, searchedString.Length).Equals(searchedString))
            {
                return index;
            }

            return -1;
        }
    }
}

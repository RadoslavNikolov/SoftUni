using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Sort_Words
{
    class SortWords
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sequence of words or \"Ctrl + C\" for exit:  ");
            string line = "";

            do
            {
                line = Console.ReadLine().Trim();
                var wordsList = new List<string>(line.Split(Convert.ToChar(" ")));
                wordsList.Sort();
                Console.WriteLine("Sorted sequence is: " + string.Join(" ", wordsList.Select(i => i.ToString())));

            } while (line != null);
        }
    }
}

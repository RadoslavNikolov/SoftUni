using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Words
{
    class SortWords
    {
        static void Main(string[] args)
        {
            var line = "";

            while (true)
            {
                Console.Write("Enter sequence of words or \"exit\": ");
                line = Console.ReadLine().Trim();

                if (line == "") continue;
                if (line == "exit") break;

                var wordsList = line.Split(' ').ToList();
                wordsList.Sort();

                wordsList.ForEach(w => Console.WriteLine(w));
            }

        }
    }
}

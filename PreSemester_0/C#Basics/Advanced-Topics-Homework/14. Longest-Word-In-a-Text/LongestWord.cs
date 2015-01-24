using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class LongestWord
{
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

        List<string> text = new List<string>(Console.ReadLine().Split(new char[] { ' ', ',', ':', ';', '.', '!', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries));
        List<string> longest = text.Distinct().OrderByDescending(c => c.Length).ThenBy(c => c).ToList();

        //print longest word
        Console.WriteLine();
        foreach (string word in longest)
        {
            if (word.Length == longest.First().Length)
            {
                Console.WriteLine(word);
            }
        }

    }
}

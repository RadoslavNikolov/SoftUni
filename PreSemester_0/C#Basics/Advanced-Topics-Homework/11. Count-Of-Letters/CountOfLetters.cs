using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


class CountOfLetters
{
    static void Main()
    {
        string input = string.Join("", Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        List<char> uniqueLetters = input.Distinct().OrderBy(x => x).ToList();


        foreach (char c in uniqueLetters)
        {
            Console.WriteLine("{0} -> {1}", c, input.Count(x => x == c));
        }       

    }
}

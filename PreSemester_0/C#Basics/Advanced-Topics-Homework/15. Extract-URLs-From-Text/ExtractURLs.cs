using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

class ExtractURLs
{
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

        List<string> text = new List<string>(Console.ReadLine().Split(new char[] { ' ', ',', ';', '!', '"', }, StringSplitOptions.RemoveEmptyEntries));
        List<string> words = new List<string> { "http://", "www." };
        text = text.Where(s => words.Any(w => s.Contains(w))).Distinct().ToList();

        if (text.Count == 0)
        {
            Console.WriteLine("\nno URLs in the text");
            return;
        }

        //printig URLs
        Console.WriteLine();
        foreach (string url in text)
        {
            Console.WriteLine(url.TrimEnd(new char[] { '.' }));
        }     
    }
}

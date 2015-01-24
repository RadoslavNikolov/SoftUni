using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "Hello";
            string word2 = "World";
            object sentence;
            sentence = word1 + " " + word2 + "!";
            Console.WriteLine(sentence);

            string typeCasting=(string)sentence;
            Console.WriteLine(typeCasting);

        }
    }
}

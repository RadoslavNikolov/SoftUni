using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Quoted_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentenceWithNoQuotations = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(sentenceWithNoQuotations);

            string sentenceWithQuotations = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(sentenceWithQuotations);
        }
    }
}

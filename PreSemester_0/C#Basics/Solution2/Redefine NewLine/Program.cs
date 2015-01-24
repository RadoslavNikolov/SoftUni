using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redefine_NewLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = {"This is the first line.",
                                 "This is the second line."};           
            Console.WriteLine("With the default new line characters");
            Console.WriteLine();
            foreach(string line in lines)
                Console.WriteLine(line);
            Console.WriteLine();

            Console.Out.NewLine = "\r\n\r\n";
     
            Console.WriteLine("With the redefined new line characters");
            foreach (string line in lines)
                Console.WriteLine(line);
        }
    }
}

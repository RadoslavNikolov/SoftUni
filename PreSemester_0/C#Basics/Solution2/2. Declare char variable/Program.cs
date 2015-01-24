using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Declare_char_variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int symbol = 72;
            Console.WriteLine("The decimal Unicoda symbol 72 is " + (char)symbol);
            
            char hexSymbol = '\u0048';
            Console.WriteLine("The decimal Unicoda symbol 72 is " + hexSymbol);


        }
    }
}

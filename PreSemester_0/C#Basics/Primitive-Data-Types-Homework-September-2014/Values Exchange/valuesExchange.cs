using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Values_Exchange
{
    class valuesExchange
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("a={0}  and   b={1}", a, b);
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("a={0}  and   b={1}",a,b);
        }
    }
}

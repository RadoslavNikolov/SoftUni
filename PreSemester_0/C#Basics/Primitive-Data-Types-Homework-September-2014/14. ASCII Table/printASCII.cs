using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ASCII_Table
{
    class printASCII
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine("Symbol {0} in the ASCII table is: {1}",i,Convert.ToChar(i));
            }
        }
    }
}

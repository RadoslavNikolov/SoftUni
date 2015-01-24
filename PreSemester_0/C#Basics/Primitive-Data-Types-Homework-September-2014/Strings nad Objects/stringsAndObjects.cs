using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_nad_Objects
{
    class stringsAndObjects
    {
        static void Main(string[] args)
        {
            string str1 = "Hello";
            string str2 = "World";
            object obj1 = str1 + " " + str2;
            string str3 = (string)obj1;
            Console.WriteLine(obj1);
            Console.WriteLine(str3);
            
        }
    }
}

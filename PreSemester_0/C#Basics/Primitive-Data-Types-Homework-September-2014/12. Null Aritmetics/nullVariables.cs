using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Null_Aritmetics
{
    class nullVariables
    {
        static void Main(string[] args)
        {
            int? var1=null;
            double? var2=null;
            Console.WriteLine(var1);
            Console.WriteLine(var2);
            var1+=5;
            var2 /= 2;
            Console.WriteLine(var1);
            Console.WriteLine(var2);
            var1 = 5;
            var2 = 2.5;
            Console.WriteLine(var1);
            Console.WriteLine(var2);
        }
    }
}

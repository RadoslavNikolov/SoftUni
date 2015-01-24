using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _13.Comparing_Floats
{
    class floatsComparing
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            const double eps=0.000001;
            Console.Write("Enter double number \"a\": ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter double number \"b\": ");
            double b =double.Parse(Console.ReadLine());
            bool success=Math.Abs(a-b)<eps;
            Console.WriteLine(success);
        }
    }
}

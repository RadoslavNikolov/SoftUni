using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NativeSQL
{
    using System.Diagnostics;
    using SuftuniContext;
    using _02_DAO;

    class NativeSQL
    {
        static void Main(string[] args)
        {
            //Problem 4
            var context = new SuftuniContext();
            var totalCount = context.Employees.Count();
            //Console.WriteLine(totalCount);

            var sw = new Stopwatch();
            sw.Start();
            DataAccessObjects.PrintNamesWithNativeQuery();
            Console.WriteLine("\nNative: {0}", sw.Elapsed);

            sw.Restart();
            DataAccessObjects.PrintNamesWithLinqQuery();
            Console.WriteLine("\nLinq: {0}", sw.Elapsed);   
        }
    }
}

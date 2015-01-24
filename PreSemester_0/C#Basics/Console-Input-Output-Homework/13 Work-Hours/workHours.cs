using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Work_Hours
{
    class workHours
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int productivity = int.Parse(Console.ReadLine());

            double sumToWork = (((days * 12.0)*90.0/100.0)*productivity/100.0);
            if (hours<=sumToWork)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine(Math.Floor(sumToWork-hours));

        }
    }
}

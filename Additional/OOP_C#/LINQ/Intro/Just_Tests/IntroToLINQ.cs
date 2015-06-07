using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro.Just_Tests
{
    class IntroToLINQ
    {
        static void Main()
        {
            int[] numbers = new int[7] {0,1,2,3,4,5,6};

            var numQuery =
                from number in numbers
                where (number%2) == 0
                select number;

            foreach (int number in numQuery)
            {
                Console.WriteLine("{0,1}", number);
            }

        }
    }
}

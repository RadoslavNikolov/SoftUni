using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Bit_Flipper_2
{
    class bitFlipper2
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int currentBit = 63;
            while (currentBit >= 2)
            {
                ulong bits = number >> (currentBit - 2) & 7;
                if (bits == 0 || bits == 7)
                {
                    number = number ^ ((ulong)7 << currentBit - 2);
                    currentBit -= 3;
                    //continue;
                }
                else
                {
                    currentBit--;
                }

            }
            Console.WriteLine(number);
        }
    }
}

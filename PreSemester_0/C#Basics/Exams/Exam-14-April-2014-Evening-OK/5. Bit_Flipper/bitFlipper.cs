using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Bit_Flipper
{
    class bitFlipper
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());

            for (int i = 62; i >=1 ;)
            {
                ulong numRight=number>>i;
                ulong currentBit = numRight & 1;

                numRight = number>>i+1;
                ulong leftBit = numRight & 1;

                numRight = number >> i - 1;
                ulong rightBit = numRight & 1;

                if (currentBit==leftBit && currentBit==rightBit)
                {
                    number = number ^ ((ulong)7 << i-1); 
                    i -= 3;
                }
                else
                {
                    i--;
                }
   
            }
            Console.WriteLine(number);
        }
    }
}

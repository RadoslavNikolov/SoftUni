using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Catch_The_Bits
{
    class catchBits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            int currentBit = 0;
            int nextBit = 1;
            string outNum = "";

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                for (int j = 7; j >= 0; j--)
                {
                    if (currentBit == nextBit)
                    {
                        int bit = (num >> j) & 1;
                        nextBit = currentBit + step;
                        outNum += bit;
                        currentBit++;
                    }
                    else
                    {
                        currentBit++;
                    }
                }
            }
            outNum = outNum.PadRight(((outNum.Length - 1) / 8 + 1) * 8, '0');
            int count = (outNum.Length - 1) / 8 + 1;
            currentBit = 0;
            for (int i = 0; i < count; i++)
            {
                string output = "";
                for (int j = 0; j < 8; j++)
                {
                    output += outNum[currentBit];
                    currentBit++;
                }
                Console.WriteLine(Convert.ToInt32(output, 2).ToString());
            }
        }
    }
}

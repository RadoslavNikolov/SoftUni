using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Friend_Bits
{
    class friendBits
    {
        static void Main(string[] args)
        {
            uint num = uint.Parse(Console.ReadLine());
            uint friendBits = 0;
            uint aloneBits = 0;
            for (int i = 31; i >= 0; i--)
            {
                uint leftBit = num >> (i + 1) & 1;
                uint rightBit = num >> (i - 1) & 1;
                uint curBit = num >> i & 1;
                if ((curBit == leftBit && i < 31)||curBit == rightBit && i > 0)
                {
                    friendBits = (friendBits << 1) | curBit;
                }
                else
                {
                    aloneBits = (aloneBits << 1) | curBit;
                }
            }           
            Console.WriteLine(friendBits);
            Console.WriteLine(aloneBits);

        }
    }
}

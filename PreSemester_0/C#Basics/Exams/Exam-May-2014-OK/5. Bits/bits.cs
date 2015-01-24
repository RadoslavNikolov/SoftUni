using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Bits
{
    class bits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                uint numP = uint.Parse(Console.ReadLine());
                uint pInverted=numP, numPShifted = numP;
                int index = Convert.ToString(numP, 2).Length;

                for (int position = 0; position < index; position++)
                {
                    pInverted = (uint)(pInverted ^ (1 << position));
                    string str = Convert.ToString(pInverted, 2);
                    pInverted = (uint)Convert.ToInt32(str, 2);
                }
                                
                string strPUpSide = new string(Convert.ToString(numP,2).ToCharArray().Reverse().ToArray());
                uint pUpSide = Convert.ToUInt32(strPUpSide, 2); 

                uint pNew = (numP ^ pInverted) & pUpSide;
                Console.WriteLine(pNew);
            }


        }
    }
}

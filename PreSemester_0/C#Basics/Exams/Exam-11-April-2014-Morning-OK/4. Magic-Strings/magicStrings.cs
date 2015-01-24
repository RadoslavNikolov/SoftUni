using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Magic_Strings
{
    class magicStrings
    {
        static void Main(string[] args)
        {
            int diff = int.Parse(Console.ReadLine());
            char[] leters = { 's', 'n', 'k', 'p' };
            int[] lettersWeight = { 3, 4, 1, 5 };
            int count = 0;
            List<string> outputStr = new List<string>();

            for (int i1 = 0; i1 < 4; i1++)
            {
                for (int i2 = 0; i2 < 4; i2++)
                {
                    for (int i3 = 0; i3 < 4; i3++)
                    {
                        for (int i4 = 0; i4 < 4; i4++)
                        {
                            for (int i5 = 0; i5 < 4; i5++)
                            {
                                for (int i6 = 0; i6 < 4; i6++)
                                {
                                    for (int i7 = 0; i7 < 4; i7++)
                                    {
                                        for (int i8 = 0; i8 < 4; i8++)
                                        {
                                            int sum1 = lettersWeight[i1] + lettersWeight[i2] + lettersWeight[i3] + lettersWeight[i4];
                                            int sum2 = lettersWeight[i5] + lettersWeight[i6] + lettersWeight[i7] + lettersWeight[i8];
                                            if (Math.Abs(sum1 - sum2) == diff)
                                            {
                                                count++;
                                                string temp = "" + leters[i1] + leters[i2] + leters[i3] + leters[i4]
                                                    + leters[i5] + leters[i6] + leters[i7] + leters[i8];
                                                outputStr.Add(temp);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            outputStr.Sort();
            if (count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(outputStr[i]);
                }
            }
        }
    }
}

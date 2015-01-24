using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NaBabaMiSmetalkata
{
    static void Main()
    {
        const string sort_CMD = "reset";
        const string right_CMD = "right";
        const string end_CMD = "stop";
        long[] numbers=new long[8];
        //input
        int abacusWidth = int.Parse(Console.ReadLine());
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        //init
        int bitCount = 0;
        string currentCommand = "";
        byte currentRowIndex;
        int position;
        long currentRow = 0;
        long mask;
        long sum = 0;

        

        //executing commands
        while (true)
        {
            currentCommand = Console.ReadLine().Trim().ToLower();
            if (currentCommand==end_CMD)
            {
                break;
            }

            if (currentCommand==sort_CMD)
            {
                for (int j = 0; j < 8; j++)
                {
                    numbers[j] = NumReset(numbers[j], abacusWidth);
                }                
            }
            else
            {
                currentRowIndex = byte.Parse(Console.ReadLine());
                position = int.Parse(Console.ReadLine());
                if (position<0)
                {
                    position = 0;
                }
                else if (position>=abacusWidth)
                {
                    position = abacusWidth - 1;
                }

                //reverse positio because bit index are opposite to the needed one
                position = abacusWidth - position - 1;

                bitCount = 0;
                currentRow=numbers[currentRowIndex];
                if (currentCommand==right_CMD)
                {
                    for (int i = 0; i <= position; i++)
                    {
                        mask = 1L << i;
                        if ((currentRow & mask)>0)
                        {
                            currentRow ^= mask;
                            currentRow |= 1L << bitCount;
                            bitCount++;
                        }
                    }
                }
                else // left command
                {
                    for (int i = abacusWidth-1; i >= position; i--)
                    {
                        mask = 1L << i;
                        if ((currentRow & mask)>0)
                        {
                            currentRow ^= mask;
                            currentRow |= 1L << (abacusWidth - 1 - bitCount);
                            bitCount++;
                        }
                    }
                }

                numbers[currentRowIndex] = currentRow;
            }
        }
        sum = CalculateSum(numbers,abacusWidth);
        Console.WriteLine(sum);
    }

    private static long NumReset(long number, int abacusWidth)
    {
        int bitCount = 0;
        for (int i = abacusWidth - 1; i >= 0; i--)
        {
            long mask = 1L << i;
            if ((number & mask) > 0)
            {
                number ^= mask;
                number |= 1L << (abacusWidth - 1 - bitCount);
                bitCount++;
            }
        }
        return number;
    }

    

    private static long CalculateSum(long[] numbers, int abacusWidth)
    {
        long sum = 0;
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            sum += numbers[i];
        }
        for (int i = 0; i < abacusWidth; i++)
        {
            long mask = 1L << i;
            if ((numbers[0] & mask) > 0 ||
                (numbers[1] & mask) > 0 ||
                (numbers[2] & mask) > 0 ||
                (numbers[3] & mask) > 0 ||
                (numbers[4] & mask) > 0 ||
                (numbers[5] & mask) > 0 ||
                (numbers[6] & mask) > 0 ||
                (numbers[7] & mask) > 0)
            {
            }
            else
            {
                count++;
            }
        }
        sum *= count;
        return sum;
    }
}

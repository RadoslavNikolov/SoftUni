using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int f = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        string leftNumStr = "";
        string rightNumStr = "";
        int froozenBit = n >> f & 1;

        string strNumber = Convert.ToString(n, 2).PadLeft(19,'0');
        if (n==0 || (n==1 && f==0))
        {
            Console.WriteLine(n);
            return;
        }
       
        if (f<18 && f>0)
        {
            for (int i = 0; i < strNumber.Length - f - 1; i++)
            {
                leftNumStr += strNumber[i];
            }
            for (int i = strNumber.Length - f; i < strNumber.Length; i++)
            {
                rightNumStr += strNumber[i];
            }
        }
        else if (f==18)
        {
            for (int i = strNumber.Length - f; i < strNumber.Length; i++)
            {
                rightNumStr += strNumber[i];
            }
        }
        else if (f==0)
        {
            for (int i = 0; i < strNumber.Length-1; i++)
            {
                leftNumStr += strNumber[i];
            }
        }

        if (f<18 && f>0)
        {
            int leftNum = Convert.ToInt32(leftNumStr, 2);
            int rightNum = Convert.ToInt32(rightNumStr, 2);

            for (int i = 0; i < r; i++)
            {
                int leftBit = leftNum & 1;
                int rightBit = rightNum & 1;
                leftNum >>= 1;
                rightNum >>= 1;
                if (leftBit == 1)
                {
                    rightNum = rightNum | (1 << rightNumStr.Length - 1);
                }
                if (rightBit == 1)
                {
                    leftNum = leftNum | (1 << leftNumStr.Length - 1);
                }
            }

            string outputNum = "" + Convert.ToString(leftNum, 2).PadLeft(leftNumStr.Length, '0') + froozenBit + Convert.ToString(rightNum, 2).PadLeft(rightNumStr.Length, '0');
            Console.WriteLine(Convert.ToInt32(outputNum, 2));
        }
        else if (f==18)
        {
            int rightNum = Convert.ToInt32(rightNumStr, 2);

            for (int i = 0; i < r; i++)
            {
                int rightBit = rightNum & 1;
                rightNum >>= 1;

                if (rightBit == 1)
                {
                    rightNum=rightNum|(1<<rightNumStr.Length-1);
                }
            }

            string outputNum = "" + froozenBit + Convert.ToString(rightNum, 2).PadLeft(rightNumStr.Length, '0');
            Console.WriteLine(Convert.ToInt32(outputNum, 2));
        }
        else if (f==0)
        {
            int leftNum = Convert.ToInt32(leftNumStr, 2);

            for (int i = 0; i < r; i++)
            {
                int leftBit = leftNum & 1;
                leftNum >>= 1;

                if (leftBit == 1)
                {
                    leftNum=leftNum|(1<<leftNumStr.Length-1);
                }
            }

            string outputNum = "" + Convert.ToString(leftNum, 2).PadLeft(rightNumStr.Length, '0') + froozenBit;
            Console.WriteLine(Convert.ToInt32(outputNum, 2));
        }
        
        

        
    }
}

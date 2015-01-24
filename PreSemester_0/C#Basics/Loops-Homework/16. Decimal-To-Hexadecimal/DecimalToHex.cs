using System;
using System.Collections.Generic;

class DecimalToHex
{
    static void Main()
    {
        Console.Write("Input decimal number: ");
        long inputNuber = long.Parse(Console.ReadLine());
        long devider = 0;
        long remainder = 0;
        List<string> outputList = new List<string>();

        do
        {
            devider = inputNuber / 16;
            remainder = inputNuber % 16;
            inputNuber = devider;
            switch (remainder)
            {
                case 10: outputList.Insert(0, "A"); break;
                case 11: outputList.Insert(0, "B"); break;
                case 12: outputList.Insert(0, "C"); break;
                case 13: outputList.Insert(0, "D"); break;
                case 14: outputList.Insert(0, "E"); break;
                case 15: outputList.Insert(0, "F"); break;
                default: outputList.Insert(0, Convert.ToString(remainder));
                    break;
            }
        } while (devider != 0);

        foreach (var item in outputList)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}

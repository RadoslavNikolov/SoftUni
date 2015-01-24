using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Input decimal number: ");
        int number = int.Parse(Console.ReadLine());
        List<int> binaryNumber = new List<int>();
        int b, remainder = 0;

        do
        {
            b = number / 2;
            remainder = number % 2;
            number = b;
            binaryNumber.Insert(0, remainder);

        } while (b != 0);

        foreach (var item in binaryNumber)
        {
            Console.Write(item);
        }
        Console.WriteLine();       
    }
}

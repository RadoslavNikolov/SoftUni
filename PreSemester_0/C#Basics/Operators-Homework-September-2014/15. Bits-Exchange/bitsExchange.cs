using System;

class bitsExchange
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < 5; i++)
        {
            uint number = uint.Parse(Console.ReadLine());
            uint numberRight = number >> 3;
            uint bit3To5 = numberRight & 7;
            numberRight=number>>24;
            uint bit24To26 = numberRight & 7;
            number = number & (~((uint)7 << 3)) | (bit24To26 << 3);
            number = number & (~((uint)7 << 24)) | (bit3To5 << 24);
            Console.WriteLine(number);
        }
    }
}

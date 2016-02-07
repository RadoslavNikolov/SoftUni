namespace _06_BitArray
{
    using System;
    using System.Numerics;


    public class Test
    {
        static void Main(string[] args)
        {
            BitArray bits = new BitArray(10);
            Console.WriteLine(bits);

            bits[0] = 1;
            bits[3] = 1;
            bits[5] = 1;
            bits[8] = 1;
            bits[9] = 1;

            //for (int i = 0; i < bits.BitsCount; i++)
            //{
            //    Console.WriteLine("arr[{0}] = {1}", i, bits[i]);
            //}

            Console.Write("bits = ");
            for (int i = 0; i < bits.BitsCount; i++)
            {
                Console.Write(bits[i]);
            }
            Console.WriteLine();
            Console.WriteLine(bits);

            Console.WriteLine(BitArrayFunctionality.ConvertToDecimal(bits));
            Console.WriteLine(BitArrayFunctionality.ConvertToHexadecimal(bits));
        }  
    }
}
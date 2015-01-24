using System;

class bitExchange
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter number: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.Write("Enter p:  ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter q:");
            int q = int.Parse(Console.ReadLine());
            Console.Write("Enter k:");
            int k = int.Parse(Console.ReadLine());

            if (p+k>32 || q+k>32)
            {
                Console.WriteLine("out of range");
            }
            else if (Math.Abs(p-q)<=k)
            {
                Console.WriteLine("overlapping");
            }
            else
            {
                uint numberRight = number >> p;
                uint bitP = numberRight & (uint)(Math.Pow(2, k) - 1);
                numberRight = number >> q;
                uint bitQ = numberRight & (uint)(Math.Pow(2, k) - 1);
                number = number & (~((uint)(Math.Pow(2, k) - 1) << p)) | (bitQ << p);
                number = number & (~((uint)(Math.Pow(2, k) - 1) << q)) | (bitP << q);
                Console.WriteLine(number);
            }
    
        }
    }
}

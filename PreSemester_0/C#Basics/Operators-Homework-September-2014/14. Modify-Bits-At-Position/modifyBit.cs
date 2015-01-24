using System;

class modifyBit
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position of bit to modify: ");
            int position = int.Parse(Console.ReadLine());
            Console.Write("Enter value to modify (0 or 1)");
            int value = int.Parse(Console.ReadLine());
            if (value==0)
            {
                number = number & ~(1 << position);
                Console.WriteLine(number);
            }
            else
            {
                number = number | (1 << position);
                Console.WriteLine(number);
            }            
        }
    }
}

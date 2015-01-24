using System;

class oddOrEven
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            int number = int.Parse(Console.ReadLine());
            //check if number is odd?
            if (number%2!=0)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

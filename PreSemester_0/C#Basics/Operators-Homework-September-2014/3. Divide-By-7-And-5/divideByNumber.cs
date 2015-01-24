using System;

class divideByNumber
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            //first way

            //if (number%7==0 && number%5==0 && number!=0)
            //{
            //    Console.WriteLine("true");
            //}
            //else
            //{
            //    Console.WriteLine("false");
            //}

            //second way
            bool success=number%7==0 && number%5==0 && number!=0;
            Console.WriteLine(success);
        }
    }
}

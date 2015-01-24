using System;


class printNumbers
{
    static void Main()
    {
        int firsNumber = 1;
        //Console.WriteLine(firsNumber);
        //Console.WriteLine(firsNumber+100);
        //Console.WriteLine(firsNumber+1000);
        Console.WriteLine(firsNumber);
        for (int i = 1; i <= 10; i++)
			{
			    Console.WriteLine(firsNumber+Math.Pow(10,i+1));

			}
    }
}
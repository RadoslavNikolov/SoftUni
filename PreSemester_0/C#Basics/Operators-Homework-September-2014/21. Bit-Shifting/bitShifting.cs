using System;

class bitShifting
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            ulong sieve = ulong.Parse(Console.ReadLine());
            number = number & ~sieve;
        }
        
        //first way
      
        //for (int i = 0; i < 64; i++)
        //{
        //    ulong numberRight = number >> i;
        //    ulong bit = numberRight & 1;
        //    if (bit == 1)
        //    {
        //        count++;
        //    }
        //}

        //second and best way
        while (number!=0)
        {           
            ulong bit = number & 1;
            if (bit==1)
            {
                count++;
            }
            number = number >> 1;
        }  
     
        Console.WriteLine(count);
    }
}

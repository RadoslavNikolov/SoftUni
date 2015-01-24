using System;

class primeCheck
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number>=2)
            {
               int count = 0;
               for (int j = 2; j <= Math.Sqrt(number); j++)
               {
                   
                   if ((number%j)==0)
                   {
                       count++;
                   }             
               }

               if (count==0)
               {
                   Console.WriteLine("true");
               }
               else
               {
                   Console.WriteLine("false");
               }

            }else
            {
                Console.WriteLine("false");
            }
            
        }
    }
}

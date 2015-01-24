using System;

class printSequence
{
    static void Main()
    {
        int firstElement = 2;
        
        for (int i = 0; i < 5; i++)
        {
            
            Console.Write("{0} ",firstElement);
            Console.Write("{0} ",-(firstElement+1));
            firstElement += 2;
        }
        Console.WriteLine();
    }
}
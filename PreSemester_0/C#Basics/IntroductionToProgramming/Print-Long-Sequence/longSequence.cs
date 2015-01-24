using System;

class longSequence
{
    static void Main()
    {
        int numberElement=1000;
        
        for (int i = 2; i < numberElement+2; i++)
        {
            
            //Console.Write("{0} ",firstElement);
            //Console.Write("{0} ",-(firstElement+1));
            //firstElement += 2;
            if (i%2==0)
	        {
                Console.Write("{0} ",i);
            }
            else
            {
                Console.Write("{0} ", -i);

            }

        }
        Console.WriteLine();
    }
    
}

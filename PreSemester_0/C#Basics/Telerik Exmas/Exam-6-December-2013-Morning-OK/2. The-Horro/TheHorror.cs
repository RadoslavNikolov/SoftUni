using System;
using System.IO;
using System.Text;

class TheHorror
{
    static void Main()
    {
        string strNumber = Console.ReadLine();
        int evenCount = 0;
        int evenSum = 0;

        for (int i = 0; i < strNumber.Length; i++)
        {
            if (strNumber[i]>='0' && strNumber[i]<='9')
            {
                if (i%2==0)
                {
                    evenSum += (int)char.GetNumericValue(strNumber[i]);
                    evenCount++; 
                }

            }


        }
        Console.WriteLine("{0} {1}",evenCount,evenSum);
    }
}

using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix =new int[n,n];


        int number=1;
        int minRows = 1;
        int maxRows = n;
        int minColls = 1;
        int maxColls = n;
 
        //fill matrix
        while (number<=(int)Math.Pow(n,2))
        {
            for (int coll = minColls; coll <= maxColls; coll++, number++)
            {
                matrix[minRows-1,coll-1]=number;
            }
            minRows++;
            for (int row = minRows; row <= maxRows; row++, number++)
            {
                matrix[row-1,maxColls-1]=number;
            }
            maxColls--;
            for (int coll = maxColls; coll >= minColls; coll--, number++)
            {
                matrix[maxRows-1,coll-1]=number;
            }
            maxRows--;
            for (int row = maxRows; row >= minRows; row--, number++)
            {
                matrix[row-1,minColls-1]=number;
            }
            minColls++;
        }

        //print matrix
        for (int row = 0; row < n; row++)
        {
            for (int coll = 0; coll < n; coll++)
            {
                Console.Write("{0,-3} ", matrix[row,coll]);
            }
            Console.WriteLine();
        }
    }
}

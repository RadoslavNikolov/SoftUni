using System;

class MatrixOfPolindromes
{
    static void Main()
    {
        int row = int.Parse(Console.ReadLine());
        int coll = int.Parse(Console.ReadLine());

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < coll; j++)
            {
                string output = "" + (char)('a' + i) + (char)('a' + i + j) + (char)('a' + i) + " ";
                Console.Write(output);
            }
            Console.WriteLine();
        }
    }
}

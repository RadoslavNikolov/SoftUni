using System;

class thirdDigit
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            bool success = new bool();
            string strNumber = Console.ReadLine();
            if (strNumber.Length<3)
            {
                Console.WriteLine(success);
            }
            else
            {
                success = (strNumber[strNumber.Length-3] == '7');
                Console.WriteLine(success);
            }
        }
    }
}

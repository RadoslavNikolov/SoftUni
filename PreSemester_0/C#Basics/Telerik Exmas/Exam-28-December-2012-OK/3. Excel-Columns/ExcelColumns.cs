using System;

class ExcelColumns
{
    static void Main()
    {
        string inputLine = "";
        long sumOfCells = 0;
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            inputLine += Console.ReadLine().ToUpper();
        }

        for (int i = inputLine.Length-1; i >= 0; i--)
        {
            sumOfCells += ((int)inputLine[i] - 64) * (long)Math.Pow(26,inputLine.Length-i-1);
        }
        Console.WriteLine(sumOfCells);
    }
}

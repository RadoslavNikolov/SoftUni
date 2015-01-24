using System;

class Sheets
{
    static void Main()
    {
        int numOfSheets = int.Parse(Console.ReadLine());

        for (int i = 10; i >= 0; i--)
        {
            int sheets = (int)Math.Pow(2, i);
            if (numOfSheets >= sheets) //use that sheet
            {
                numOfSheets -= sheets;
            }
            else
            {
                Console.WriteLine("A{0}",10-i);
            }
        }
    }
}

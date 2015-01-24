using System;

class illuminati
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        inputLine = inputLine.ToUpper();
        int sum = 0;
        int count = 0;
        foreach (var item in inputLine)
        {
            if (item=='A' || item=='E' || item=='I' || item=='O' || item=='U')
            {
                sum += item;
                count++;
            }          
        }
        Console.WriteLine(count);
        Console.WriteLine(sum);
    }
}

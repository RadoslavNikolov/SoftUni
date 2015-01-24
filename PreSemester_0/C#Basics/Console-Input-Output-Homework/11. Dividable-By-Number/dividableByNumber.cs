using System;

class dividableByNumber
{
    static void Main()
    {
        Console.Write("Enter start of the range: ");
        int startNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the end of the range: ");
        int endNum = int.Parse(Console.ReadLine());
        int count = 0;
        string strNum="";
        for (int i = startNum; i <= endNum; i++)
        {
            if (i%5==0)
            {
                count++;
                strNum += i + ", ";
            }
        }
        Console.WriteLine("|{0,-5}|{1}|", "p", "comments".PadRight(strNum.Length,' '));
        Console.WriteLine("|{0,-5}|{1}|", count, strNum.PadRight(strNum.Length,' '));
    }
}

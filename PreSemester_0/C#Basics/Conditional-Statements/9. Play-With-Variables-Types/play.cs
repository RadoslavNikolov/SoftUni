using System;
using System.Threading;

class play
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        Console.WriteLine("Plaease choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1": Console.Write("Please enter an int: ");
                      int intVar = int.Parse(Console.ReadLine());
                      Console.WriteLine(intVar+1);
                      break;
            case "2": Console.Write("Please enter a double: ");
                      double doubleVar = double.Parse(Console.ReadLine());
                      Console.WriteLine(doubleVar + 1.0);
                      break;
            case "3": Console.Write("Please enter a string: ");
                      string strVar = Console.ReadLine();
                      Console.WriteLine(strVar + "*");
                      break;
            default:
                break;
        }
    }
}

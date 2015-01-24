using System;
using System.Threading;
using System.Globalization;

class CoffeeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        int tray005 = int.Parse(Console.ReadLine());
        int tray010 = int.Parse(Console.ReadLine());
        int tray020 = int.Parse(Console.ReadLine());
        int tray050 = int.Parse(Console.ReadLine());
        int tray100 = int.Parse(Console.ReadLine());
        double amaunt = double.Parse(Console.ReadLine());
        double drinkPrice = double.Parse(Console.ReadLine());
        double changeAvailable = tray005 * 0.05 + tray010 * 0.1 + tray020 * 0.2 + tray050 * 0.5 + tray100 * 1.0;

        if (drinkPrice>amaunt)
        {
            Console.WriteLine("More {0:F2}", drinkPrice-amaunt);
        }
        else
        {
            if (amaunt-drinkPrice<=changeAvailable)
            {
                Console.WriteLine("Yes {0:F2}", changeAvailable-(amaunt-drinkPrice));
            }
            else
            {
                Console.WriteLine("No {0:F2}", (amaunt-drinkPrice)-changeAvailable);
            }
        }

    }
}

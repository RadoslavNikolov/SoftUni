using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class fruitMarket
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        string dayOfWeek = Console.ReadLine();
        decimal quantity1 = decimal.Parse(Console.ReadLine());
        string product1 = Console.ReadLine();
        decimal quantity2 = decimal.Parse(Console.ReadLine());
        string product2 = Console.ReadLine();
        decimal quantity3 = decimal.Parse(Console.ReadLine());
        string product3 = Console.ReadLine();

        decimal totalSum =
            quantity1 * GetPrice(product1,dayOfWeek) +
            quantity2 * GetPrice(product2, dayOfWeek) +
            quantity3 * GetPrice(product3, dayOfWeek);
        Console.WriteLine("{0:F2}",totalSum);
    }

    private static decimal GetPrice(string productName, string dayOfWeek)
    {
        decimal price = 0m;
        bool isFruit = false;
        switch (productName)
        {
            case "banana": price = 1.8m; isFruit = true; break;
            case "cucumber": price = 2.75m; break;
            case "tomato": price = 3.2m; break;
            case "orange": price = 1.6m; isFruit = true; break;
            case "apple": price = 0.86m; isFruit = true; break;
            default:
                break;
        }

        switch (dayOfWeek)
        {
            case "Friday": price *= 0.9m; break;
            case "Sunday": price *= 0.95m; break;
            case "Tuesday":
                            if (isFruit)
                            {
                                price*=0.8m;
                            }
                            break;
            case "Wednesday":
                            if (!isFruit)
                            {
                                price*=0.9m;
                            }
                            break;
            case "Thursday":
                            if (productName=="banana")
                            {
                                price*=0.7m;
                            }
                            break;
            default:
                break;
        }

        return price;
    }
}

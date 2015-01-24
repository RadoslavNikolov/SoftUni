using System;
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
        decimal sum;
        

        switch (dayOfWeek)
        {
            case "Tuesday": 
                            sum=priceCalculation(quantity1, product1, quantity2, product2, quantity3, product3, 0.8m, "fruits");
                            Console.WriteLine("{0:F2}",sum);
                            break;
            case "Wednesday": 
                            sum=priceCalculation(quantity1, product1, quantity2, product2, quantity3, product3, 0.9m, "vegetables");
                            Console.WriteLine("{0:F2}", sum);
                            break;
            case "Thursday": 
                            sum = priceCalculation(quantity1, product1, quantity2, product2, quantity3, product3, 0.7m, "banana");
                            Console.WriteLine("{0:F2}", sum);
                            break;
            case "Friday": 
                          sum=priceCalculation(quantity1, product1, quantity2, product2, quantity3, product3, 0.9m, "all");
                          Console.WriteLine("{0:F2}", sum);
                          break;
            case "Sunday": 
                          sum=priceCalculation(quantity1, product1, quantity2, product2, quantity3, product3, 0.95m, "all");
                          Console.WriteLine("{0:F2}", sum);
                          break;
            case "Saturday":
            case "Monday": 
                          sum=priceCalculation(quantity1, product1, quantity2, product2, quantity3, product3, 1.0m, "all");
                          Console.WriteLine("{0:F2}", sum);
                          break;
            default:
                break;
        }
    }

    static decimal priceCalculation(decimal quantity1, string product1, decimal quantity2, 
                                            string product2, decimal quantity3, string product3, decimal discount, string type)
    {
        string[] products = { "banana", "cucumber", "tomato", "orange", "apple" };
        decimal[] prices = { 1.8m, 2.75m, 3.2m, 1.6m, 0.86m };
        decimal sum = 0.0m;

        if (type=="all")
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == product1)
                {
                    sum+= quantity1*prices[i];
                }
                else if (products[i] == product2)
                {
                    sum+= quantity2*prices[i];
                }
                else if (products[i] == product3)
                {
                    sum+= quantity3*prices[i];
                }
            }
            sum *= discount;
        }

        if (type=="banana")
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == product1)
                {
                    if (products[i]=="banana")
                    {
                        sum += quantity1 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity1 * prices[i];
                    }
                }
                else if (products[i] == product2)
                {
                    if (products[i] == "banana")
                    {
                        sum += quantity2 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity2 * prices[i];
                    }
                }
                else if (products[i] == product3)
                {
                    if (products[i] == "banana")
                    {
                        sum += quantity3 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity3 * prices[i];
                    }
                }
            }
        }

        if (type=="fruits")
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == product1)
                {
                    if (products[i] == "banana" || products[i] == "orange" || products[i] == "apple")
                    {
                        sum += quantity1 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity1 * prices[i];
                    }
                    
                }
                else if (products[i] == product2)
                {
                    if (products[i] == "banana" || products[i] == "orange" || products[i] == "apple")
                    {
                        sum += quantity2 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity2 * prices[i];
                    }
                }
                else if (products[i] == product3)
                {
                    if (products[i] == "banana" || products[i] == "orange" || products[i] == "apple")
                    {
                        sum += quantity3 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity3 * prices[i];
                    }
                }   
            }
        }

        if (type == "vegetables")
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == product1)
                {
                    if (products[i] == "cucumber" || products[i] == "tomato")
                    {
                        sum += quantity1 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity1 * prices[i];
                    }
                    
                }
                else if (products[i] == product2)
                {
                    if (products[i] == "cucumber" || products[i] == "tomato")
                    {
                        sum += quantity2 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity2 * prices[i];
                    }
                }
                else if (products[i] == product3)
                {
                    if (products[i] == "cucumber" || products[i] == "tomato")
                    {
                        sum += quantity3 * prices[i] * discount;
                    }
                    else
                    {
                        sum += quantity3 * prices[i];
                    }
                }
            }
        }


        return sum;
    }
}

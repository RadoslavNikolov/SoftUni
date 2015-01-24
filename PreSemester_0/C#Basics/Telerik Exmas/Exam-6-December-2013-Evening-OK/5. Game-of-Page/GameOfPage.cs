using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Warhead
{
    static void Main()
    {
        const int panelWidth = 16;
        int[] numbers = new int[panelWidth];
        int currentRow = new int();
        int upperRow = new int();
        int lowerRow = new int();
        int mask = new int();
        double takenCookie = 0.0;
        double sum = 0.0;
        double priceOfCookie = 1.79;
        string currentCommand = "";
        int currentX;
        int currentY;
        StringBuilder result = new StringBuilder();

        //initializing input data
        for (int i = 0; i < panelWidth; i++)
        {
            numbers[i] = Convert.ToInt32(Console.ReadLine(), 2);
        }

        //reading commands
        while (true)
        {
            currentCommand = Console.ReadLine();
            if (currentCommand == "what is")
            {
                currentY = int.Parse(Console.ReadLine());
                currentX = panelWidth - int.Parse(Console.ReadLine()) - 1;
                mask = 1 << currentX;

                currentRow = numbers[currentY];
                if ((currentY > 0) && (currentY < 15))
                {
                    upperRow = numbers[currentY - 1];
                    lowerRow = numbers[currentY + 1];
                }
                else if (currentY == 0)
                {
                    lowerRow = numbers[currentY + 1];
                    if ((currentRow & mask) > 0)
                    {
                        if ((lowerRow & mask) == 0 &&
                        (currentRow & (mask << 1)) == 0 &&
                        (lowerRow & (mask << 1)) == 0 &&
                        (currentRow & (mask >> 1)) == 0 &&
                        (lowerRow & (mask >> 1)) == 0)
                        {
                            result.AppendLine("cookie crumb");
                            continue;
                        }
                        else
                        {
                            result.AppendLine("broken cookie");
                            continue;
                        }
                    }
                    else
                    {
                        result.AppendLine("smile");
                        continue;
                    }
                }
                else if (currentY == 15)
                {
                    upperRow = numbers[currentY - 1];
                    if ((currentRow & mask) > 0)
                    {
                        if ((upperRow & mask) == 0 &&
                        (currentRow & (mask << 1)) == 0 &&
                        (upperRow & (mask << 1)) == 0 &&
                        (currentRow & (mask >> 1)) == 0 &&
                        (upperRow & (mask >> 1)) == 0)
                        {
                            result.AppendLine("cookie crumb");
                            continue;
                        }
                        else
                        {
                            result.AppendLine("broken cookie");
                            continue;
                        }
                    }
                    else
                    {
                        result.AppendLine("smile");
                        continue;
                    }
                }

                if ((currentRow & mask) > 0)
                {
                    if ((upperRow & mask) > 0 &&
                        (lowerRow & mask) > 0 &&
                        (currentRow & (mask << 1)) > 0 &&
                        (upperRow & (mask << 1)) > 0 &&
                        (lowerRow & (mask << 1)) > 0 &&
                        (currentRow & (mask >> 1)) > 0 &&
                        (upperRow & (mask >> 1)) > 0 &&
                        (lowerRow & (mask >> 1)) > 0)
                    {
                        result.AppendLine("cookie");
                    }
                    else if ((upperRow & mask) == 0 &&
                        (lowerRow & mask) == 0 &&
                        (currentRow & (mask << 1)) == 0 &&
                        (upperRow & (mask << 1)) == 0 &&
                        (lowerRow & (mask << 1)) == 0 &&
                        (currentRow & (mask >> 1)) == 0 &&
                        (upperRow & (mask >> 1)) == 0 &&
                        (lowerRow & (mask >> 1)) == 0)
                    {
                        result.AppendLine("cookie crumb");
                    }
                    else
                    {
                        result.AppendLine("broken cookie");
                        continue;
                    }
                }
                else
                {
                    result.AppendLine("smile");
                    continue;
                }
            }

            if (currentCommand == "buy")
            {
                currentY = int.Parse(Console.ReadLine());
                currentX = panelWidth - int.Parse(Console.ReadLine()) - 1;
                mask = 1 << currentX;

                currentRow = numbers[currentY];
                if (currentY > 0 && currentY < 15)
                {
                    upperRow = numbers[currentY - 1];
                    lowerRow = numbers[currentY + 1];

                    if ((currentRow & mask) > 0)
                    {
                        if ((upperRow & mask) > 0 &&
                            (lowerRow & mask) > 0 &&
                            (currentRow & (mask << 1)) > 0 &&
                            (upperRow & (mask << 1)) > 0 &&
                            (lowerRow & (mask << 1)) > 0 &&
                            (currentRow & (mask >> 1)) > 0 &&
                            (upperRow & (mask >> 1)) > 0 &&
                            (lowerRow & (mask >> 1)) > 0)
                        {
                            takenCookie++;

                            currentRow ^= mask;
                            upperRow ^= mask;
                            lowerRow ^= mask;

                            mask = mask << 1;
                            currentRow ^= mask;
                            upperRow ^= mask;
                            lowerRow ^= mask;

                            mask = mask >> 2;
                            currentRow ^= mask;
                            upperRow ^= mask;
                            lowerRow ^= mask;

                            numbers[currentY] = currentRow;
                            numbers[currentY - 1] = upperRow;
                            numbers[currentY + 1] = lowerRow;
                        }
                        else
                        {
                            result.AppendLine("page");
                            continue;
                        }
                    }
                    else
                    {
                        result.AppendLine("smile");
                        continue;
                    }
                }
                else
                {
                    if ((currentRow & mask) > 0)
                    {
                        result.AppendLine("page");
                        continue;
                    }
                    else
                    {
                        result.AppendLine("smile");
                        continue;
                    }
                }             
            }
            
            if (currentCommand == "paypal")
            {
                sum = takenCookie * priceOfCookie;
                break;
            }
        }
        Console.Write(result);
        Console.WriteLine("{0:F2}",sum);
    }
}

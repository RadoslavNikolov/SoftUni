using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Warhead
{
    static void Main()
    {
        const int panelWidth=16;
        int[] numbers = new int[panelWidth];
        int currentRow = new int();
        int upperRow = new int();
        int lowerRow = new int();
        int mask = new int();
        int leftCircuitCount = 0;
        int rightCircuitCount = 0;
        List<int> xPositionArray = new List<int>();
        List<int> YPositionArray = new List<int>();
        string currentCommand = "";
        bool explode = false;
        bool? cutRedWire = null;
        int currentX;
        int currentY;
        StringBuilder result = new StringBuilder();

        //initializing input data
        for (int i = 0; i < panelWidth; i++)
        {
            numbers[i] = Convert.ToInt32(Console.ReadLine(),2);
        }

        //counting the figures
        //selecting current line and assigning upper and lower lines as well
        for (int currentLine = 1; currentLine < panelWidth - 1; currentLine++)
        {
            currentRow = numbers[currentLine];
            upperRow = numbers[currentLine - 1];
            lowerRow = numbers[currentLine + 1];

            for (int i = 1; i < 15; i++)
            {
                mask = 1 << i;
                if ((currentRow & mask) == 0 && (upperRow & mask) > 0 && (lowerRow & mask) > 0)
                {
                    mask = mask << 1;
                    if ((currentRow & mask) > 0 && (upperRow & mask) > 0 && (lowerRow & mask) > 0)
                    {
                        mask = mask >> 2;
                        if ((currentRow & mask) > 0 && (upperRow & mask) > 0 && (lowerRow & mask) > 0)
                        {
                            if (i > 7)
                            {
                                leftCircuitCount++;
                            }
                            else
                            {
                                rightCircuitCount++;
                            }
                            xPositionArray.Add(i);
                            YPositionArray.Add(currentLine);
                            i += 2;
                        }
                    }
                }
            }
        }

        //reading commands
        while (true)
        {
            currentCommand = Console.ReadLine();
            if (currentCommand=="cut")
            {
                currentCommand = Console.ReadLine();
                if (currentCommand=="red")
                {
                    cutRedWire=true;
                    if (leftCircuitCount!=0)
                    {
                        explode = true;
                    }
                }
                else
                {
                    cutRedWire = false;
                    if (rightCircuitCount!=0)
                    {
                        explode = true;
                    }
                }
                break;
            }
            else //hover or operate
            {
                //read positions
                currentY = int.Parse(Console.ReadLine());
                currentX = panelWidth - int.Parse(Console.ReadLine()) - 1;
                mask = 1 << currentX;

                currentRow = numbers[currentY];
                if (currentY > 0)
                {
                    upperRow = numbers[currentY - 1];
                }
                if (currentY < 15)
                {
                    lowerRow = numbers[currentY + 1];
                    
                }             

                if (currentCommand=="hover")
                {
                    if ((currentRow&mask)>0)
                    {
                        result.AppendLine("*");
                    }
                    else
                    {
                        result.AppendLine("-");
                    }
                }
                else  //operates at the current position
                {
                    if ((currentRow&mask)>0)
                    {
                        explode = true;
                        break;
                    }
                    else
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

                            // Record the change
                            if (currentX > 7)
                            {
                                leftCircuitCount--;
                            }
                            else
                            {
                                rightCircuitCount--;
                            }

                            numbers[currentY] = currentRow;
                            numbers[currentY - 1] = upperRow;
                            numbers[currentY + 1] = lowerRow;
                        }
                        else
                        {
                            continue;
                        }                      
                    }
                }

            }
            
        }

        if (explode)
        {
            if (cutRedWire.HasValue) // One of the wires was cut
            {
                if (cutRedWire == true)
                {
                    result.AppendLine(leftCircuitCount.ToString());
                }
                else
                {
                    result.AppendLine(rightCircuitCount.ToString());
                }
            }
            else // A capacitor was hit
            {
                result.AppendLine("missed");
                result.AppendLine((leftCircuitCount + rightCircuitCount).ToString());
            }
            result.AppendLine("BOOM"); 
        }
        else 
        {
            if (cutRedWire == true)
            {
                result.AppendLine(rightCircuitCount.ToString());
                result.AppendLine("disarmed");
            }
            else if (cutRedWire == false)
            {
                result.AppendLine(leftCircuitCount.ToString());
                result.AppendLine("disarmed");
            }
        }

        Console.Write(result);       
    }
}

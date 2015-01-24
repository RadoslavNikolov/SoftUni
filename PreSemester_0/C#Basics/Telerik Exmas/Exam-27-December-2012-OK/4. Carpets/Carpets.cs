using System;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outerPartCount = (n/2) - 1;
        for (int i = 0; i < n/2; i++)
        {
            string outerPart = new string('.',outerPartCount);
            Console.Write(outerPart);
            int middlePartCount = n - (2 * outerPartCount);
            if ((middlePartCount/2)%2!=0)
            {
                for (int j = 0; j < middlePartCount/2; j++)
                {
                    if (j%2==0)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

            }
            else
            {
                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\\");
                    }
                }
            }
            Console.Write(outerPart);
            Console.WriteLine();
            if (outerPartCount>0)
            {
                outerPartCount--;                
            }
        }

        for (int i = 0; i < n / 2; i++)
        {
            string outerPart = new string('.', outerPartCount);
            Console.Write(outerPart);
            int middlePartCount = n - (2 * outerPartCount);
            if ((middlePartCount / 2) % 2 != 0)
            {
                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

            }
            else
            {
                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                for (int j = 0; j < middlePartCount / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
            }
            Console.Write(outerPart);
            Console.WriteLine();
            outerPartCount++;
        }
    }
}


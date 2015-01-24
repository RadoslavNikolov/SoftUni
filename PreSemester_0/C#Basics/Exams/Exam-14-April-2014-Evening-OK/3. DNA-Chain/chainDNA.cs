using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DNA_Chain
{
    class chainDNA
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char startLetter=Convert.ToChar(Console.ReadLine());
            int count = 1;
            int i = 1;

            for (int j = 0; j < n/7+1; j++)
            {
                for (int row = 1; row <= 7; row++)
                {
                    if (i > n)
                    {
                        break;
                    }
                    else
                    {
                        if (row <= 7 / 2 + 1)
                        {
                            for (int coll = 1; coll <= 7; coll++)
                            {
                            start:
                                if (startLetter <= 'G')
                                {
                                    if (coll <= (7 - count) / 2 || coll > (7 - count) / 2 + count)
                                    {
                                        Console.Write('.');
                                    }
                                    else
                                    {
                                        Console.Write(startLetter);
                                        startLetter++;
                                    }
                                }
                                else
                                {
                                    startLetter = 'A';
                                    goto start;
                                }

                            }
                            Console.WriteLine();
                            i++;
                            if (count < 7)
                            {
                                count += 2;
                            }

                        }
                        else
                        {
                            count -= 2;
                            for (int coll = 1; coll <= 7; coll++)
                            {
                            start:
                                if (startLetter <= 'G')
                                {
                                    if (coll <= (7 - count) / 2 || coll > (7 - count) / 2 + count)
                                    {
                                        Console.Write('.');
                                    }
                                    else
                                    {
                                        Console.Write(startLetter);
                                        startLetter++;
                                    }
                                }
                                else
                                {
                                    startLetter = 'A';
                                    goto start;
                                }

                            }

                            Console.WriteLine();
                            i++;
                        }
                    }


                }  
            }
            
        }
    }
}

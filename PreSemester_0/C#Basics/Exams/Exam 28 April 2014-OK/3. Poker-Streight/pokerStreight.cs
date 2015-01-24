using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Poker_Streight
{
    class pokerStreight
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int count = 0;
            
            for (int face = 0; face < 10; face++)
            {
                for (int suit1 = 1; suit1 <= 4; suit1++)
                {
                    for (int suit2 = 1; suit2 <= 4; suit2++)
                    {
                        for (int suit3 = 1; suit3 <= 4; suit3++)
                        {
                            for (int suit4 = 1; suit4 <= 4; suit4++)
                            {
                                for (int suit5 = 1; suit5 <= 4; suit5++)
                                {
                                    int sum =
                                        (face + 1) * 10 + suit1 +
                                        (face + 2) * 20 + suit2 +
                                        (face + 3) * 30 + suit3 +
                                        (face + 4) * 40 + suit4 +
                                        (face + 5) * 50 + suit5;

                                    if (sum==w)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}

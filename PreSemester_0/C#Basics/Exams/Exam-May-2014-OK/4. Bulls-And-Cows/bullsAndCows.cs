using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Bulls_And_Cows
{
    class bullsAndCows
    {
        static void Main(string[] args)
        {
            string secretNum = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int count = 0;
            string output = "";
            for (int Num = 1111; Num <= 9999; Num++)
            {
                char[] guesNum = Num.ToString().ToCharArray();
                if (guesNum[0]>='1'&&guesNum[1]>='1'&&guesNum[2]>='1'&&guesNum[3]>='1')
                {
                    char[] secNum = secretNum.ToString().ToCharArray();
                    int bulls = 0;
                    int cows = 0;
                    for (int i = 0; i < guesNum.Length; i++)
                    {
                        if (guesNum[i]==secNum[i])
                        {
                            bulls++;
                            secNum[i] = 'S';
                            guesNum[i] = 'G';
                        }
                    }

                    for (int sec = 0; sec < secNum.Length; sec++)
                    {
                        for (int gues = 0; gues < guesNum.Length; gues++)
                        {
                            if (guesNum[gues]==secNum[sec])
                            {
                                cows++;
                                secNum[sec] = 'S';
                                guesNum[gues] = 'G';
                            }
                        }
                    }

                    if (bulls==b && cows==c)
                    {
                        count++;
                        output += " " + Num;
                    }
                }
            }

            if (count==0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(output.Trim());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _12.Falling_Rocks
{
    class fallingRocks
    {
        static void Main(string[] args)
        {
            const int playGround_Height = 25;
            const int playGroung_Wight = 70;

            int playerPositionX = playGroung_Wight/2;

            Random randomGenerator = new Random();

            Console.CursorVisible = false;
            Console.WindowHeight = playGround_Height;
            Console.BufferHeight = Console.WindowHeight;
            Console.WindowWidth = playGroung_Wight;
            Console.BufferWidth = Console.WindowWidth;

            Console.SetCursorPosition(playerPositionX,playGround_Height-1);
            Console.Write("(0)");

            for (int i = 0; i <= randomGenerator.Next(2,4); i++)
            {
                int rockX = randomGenerator.Next(0, playGroung_Wight);
                int rockY = 0;
                Console.SetCursorPosition(rockX, rockY);
                int rockType = randomGenerator.Next(1, 12);
                switch (rockType)
                {
                    case 1: Console.Write("^"); break;
                    case 2: Console.Write("@"); break;
                    case 3: Console.Write("*"); break;
                    case 4: Console.Write("&"); break;
                    case 5: Console.Write("+"); break;
                    case 6: Console.Write("%"); break;
                    case 7: Console.Write("$"); break;
                    case 8: Console.Write("#"); break;
                    case 9: Console.Write("!"); break;
                    case 10: Console.Write("."); break;
                    case 11: Console.Write(";"); break;
                    case 12: Console.Write("-"); break;
                    default: break;
                }
            }


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        playerPositionX -= 2;
                        if (playerPositionX < 0)
                        {
                            playerPositionX = 0;
                        }
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        playerPositionX += 2;
                        if (playerPositionX > playGroung_Wight - 4)
                        {
                            playerPositionX = playGroung_Wight - 4;
                        }
                    }
                }


                Console.Clear();

                Console.SetCursorPosition(playerPositionX, playGround_Height - 1);
                Console.Write("(0)");



                Thread.Sleep(80);
            }          

        }
    }
}

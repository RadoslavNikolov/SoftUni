using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tennis_Game
{
    class tennisGame
    {
        static void Main(string[] args)
        {
            const int playGround_Height = 20;
            const int padHeight = 5;
            const char ball_Char = '*';

            int playerPositionY = 8;
            int ballX, ballY;
            int ball_Direction;
            Random randomGenerator=new Random();
            ballX = randomGenerator.Next(15, 65);
            ballY = randomGenerator.Next(3, 17);
            ball_Direction = randomGenerator.Next(1, 4);


            Console.CursorVisible = false;
            Console.WindowHeight = playGround_Height;
            Console.BufferHeight = Console.WindowHeight;

            for (int i = 0; i < padHeight; i++)
            {
                Console.SetCursorPosition(0, playerPositionY + i);
                Console.Write('|');
            }
            Console.SetCursorPosition(ballX, ballY);
            Console.WriteLine(ball_Char);
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        playerPositionY-=2;
                        if (playerPositionY < 0)
                        {
                            playerPositionY = 0;
                        }
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        playerPositionY+=2;
                        if (playerPositionY > playGround_Height - padHeight)
                        {
                            playerPositionY = playGround_Height - padHeight;
                        }
                    } 
                }
                
                

                switch (ball_Direction)
                {
                    case 1:
                        ballX--;
                        ballY--;
                        break;
                    case 2:
                        ballX++;
                        ballY--;
                        break;
                    case 3:
                        ballX++;
                        ballY++;
                        break;
                    case 4:
                        ballX--;
                        ballY++;
                        break;

                }
                if (ballX==0)
                {
                    if ((ballY >= playerPositionY) && (ballY <= playerPositionY+4))
                    {
                        if (ball_Direction == 1)
                        {
                            ball_Direction = 2;
                        }
                        else if (ball_Direction == 4)
                        {
                            ball_Direction = 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game Over");
                        return;
                    }
                    if (ball_Direction==1)
                    {
                        ball_Direction = 2;
                    }
                    else if(ball_Direction==4)
                    {
                        ball_Direction = 3;
                    }
                }
                if (ballX==79)
                {
                    if (ball_Direction == 2)
                    {
                        ball_Direction = 1;
                    }
                    else if (ball_Direction == 3)
                    {
                        ball_Direction = 4;
                    }
                }

                if (ballY==0)
                {
                    if (ball_Direction == 2)
                    {
                        ball_Direction = 3;
                    }
                    else if (ball_Direction == 1)
                    {
                        ball_Direction = 4;
                    }
                }else if (ballY==playGround_Height-1)
                {
                    if (ball_Direction == 3)
                    {
                        ball_Direction = 2;
                    }
                    else if (ball_Direction == 4)
                    {
                        ball_Direction = 1;
                    }
                }

                Console.Clear();
                for (int i = 0; i < padHeight; i++)
                {
                    Console.SetCursorPosition(0, playerPositionY + i);
                    Console.Write('|');
                }

                Console.SetCursorPosition(ballX, ballY);
                Console.WriteLine(ball_Char);

                Thread.Sleep(80);
            }


        }
    }
}

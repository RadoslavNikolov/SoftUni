using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class CardWarsBatka
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger sumFirstPlayer = 0;
        BigInteger sumSecondPlayer = 0;
        bool xCardFirstPlayer = false;
        bool xCardSecondPlayer = false;
        
        int gameWonFirstPlayer = 0;
        int gameWonSecondPlayer = 0;

        for (int i = 0; i < n; i++)
        {
            int cardStrenghtFirstPlayer = 0;
            int cardStrenghtSecondPlayer = 0;

            //first player card
            for (int j = 0; j < 3; j++)
            {
                string card = Console.ReadLine();
                switch (card)
                {
                    case "A": cardStrenghtFirstPlayer += 1; break;
                    case "J": cardStrenghtFirstPlayer += 11; break;
                    case "Q": cardStrenghtFirstPlayer += 12; break;
                    case "K": cardStrenghtFirstPlayer += 13; break;
                    case "Z": sumFirstPlayer *= 2; break;
                    case "Y": sumFirstPlayer -= 200; break;
                    case "X": xCardFirstPlayer = true; break;
                    default: cardStrenghtFirstPlayer += 12 - int.Parse(card);
                        break;
                }
            }

            //second player card
            for (int j = 0; j < 3; j++)
            {
                string card = Console.ReadLine();
                switch (card)
                {
                    case "A": cardStrenghtSecondPlayer += 1; break;
                    case "J": cardStrenghtSecondPlayer += 11; break;
                    case "Q": cardStrenghtSecondPlayer += 12; break;
                    case "K": cardStrenghtSecondPlayer += 13; break;
                    case "Z": sumSecondPlayer *= 2; break;
                    case "Y": sumSecondPlayer -= 200; break;
                    case "X": xCardSecondPlayer = true; break;
                    default: cardStrenghtSecondPlayer += 12 - int.Parse(card);
                        break;
                }
            }

            if (xCardFirstPlayer && xCardSecondPlayer==false)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                Environment.Exit(0);
            }
            else if (xCardSecondPlayer && xCardFirstPlayer==false)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");                
                Environment.Exit(0);
            }
            else if (xCardFirstPlayer && xCardSecondPlayer)
            {
                sumFirstPlayer += 50;
                sumSecondPlayer += 50;
                xCardFirstPlayer = false;
                xCardSecondPlayer = false;
                continue;
            }

            if (cardStrenghtFirstPlayer > cardStrenghtSecondPlayer)
            {
                sumFirstPlayer += cardStrenghtFirstPlayer;
                gameWonFirstPlayer++;
            }
            else if (cardStrenghtFirstPlayer < cardStrenghtSecondPlayer)
            {
                sumSecondPlayer += cardStrenghtSecondPlayer;
                gameWonSecondPlayer++;
            }
        }

        if (sumFirstPlayer==sumSecondPlayer)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", sumFirstPlayer);
        }
        else if (sumFirstPlayer>sumSecondPlayer)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", sumFirstPlayer);
            Console.WriteLine("Games won: {0}", gameWonFirstPlayer);
        }
        else
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", sumSecondPlayer);
            Console.WriteLine("Games won: {0}", gameWonSecondPlayer);
        }
    }
}

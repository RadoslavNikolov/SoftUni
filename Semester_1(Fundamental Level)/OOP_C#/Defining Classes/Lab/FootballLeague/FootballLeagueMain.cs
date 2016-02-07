using System;
using System.Runtime.CompilerServices;
using FootballLeague.Exceptions;

namespace FootballLeague
{
    class FootballLeagueMain
    {
        static void Main()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                try
                {
                    LeagueManager.HandleInput(line);
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine("     !!! " + ex.Message + "\n");
                }
                catch (DublicatingTeams ex)
                {
                    Console.WriteLine("     !!! " + ex.Message + "\n");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("     !!! " + ex.Message + "\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("     !!! " + ex.Message + "\n");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("     !!! " + ex.Message + "\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("     !!! Something went wrong \n");
                }

                line = Console.ReadLine();
            }
        }
    }
}

namespace ToTheStars
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Interfaces;
    using Models;

    public class ToTheStarsProgram
    {
        private static readonly IList<IGalaxy> GalxiesList = new List<IGalaxy>();

        public static void Main()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter {0} galaxy information \"<name> <x> <y>\": ", i + 1);
                var inputLine = Console.ReadLine();
                ProcessInputLine(inputLine);
            }

            Console.Write("Enter coordinates for \"Normandy\" starship: ");
            var coordStr = Console.ReadLine();
            var coordTokens = Regex.Split(coordStr, @"\s+", RegexOptions.IgnoreCase);
            var coordinates = new Point2D(double.Parse(coordTokens[0].Trim()), double.Parse(coordTokens[1].Trim()));
            var starship = new Starship(coordinates);

            Console.Write("Enter number of turns: ");
            var turns = int.Parse(Console.ReadLine().Trim());

            var isRunning = true;
            do
            {
                Console.WriteLine(CheckForIntersection(starship));
                starship.MoveUp();

                if (starship.Coordinates.Y >= 30 || turns == 0)
                {
                    isRunning = false;
                }

                turns--;
            } while (isRunning);
        }

        private static string CheckForIntersection(Starship starship)
        {
            var result = "space";
            foreach (var galaxy in GalxiesList)
            {
                if (galaxy.IsIntersecting(starship.Coordinates))
                {
                    result = galaxy.GalaxyName.ToLower();
                }
            }

            return result;
        }

        private static void ProcessInputLine(string inputLine)
        {
            var inputTokens = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase);
            if (inputTokens.Length != 3)
            {
                return;
            }

            var galaxyName = inputTokens[0].Trim();
            var coordinates = new Point2D(double.Parse(inputTokens[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture), double.Parse(inputTokens[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture));
            var newGalaxy = new Galaxy(galaxyName, coordinates);

            GalxiesList.Add(newGalaxy);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingTest
{
    using System.Text.RegularExpressions;

    class Program
    {
        private static readonly ISet<string> ParkingLot = new HashSet<string>();
        private static int rowsCount;
        private static int colsCount;

        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var tokens = Regex.Split(inputLine, @"\s+").Select(int.Parse).ToArray();

            //var tokens = inputLine.Split(' ').Select(int.Parse).ToArray();
            rowsCount = tokens[0];
            colsCount = tokens[1];

            while (true)
            {
                inputLine = Console.ReadLine().Trim();

                if (inputLine.ToLower().Equals("stop"))
                {
                    break;
                }
                tokens = Regex.Split(inputLine, @"\s+").Select(int.Parse).ToArray();
                //tokens = inputLine.Split(' ').Select(int.Parse).ToArray();
                var initialPosition = tokens[0];
                var targetX = tokens[2];
                var targetY = tokens[1];

                DoPark(initialPosition, targetX, targetY);
                    
            }
        }

        private static void DoPark(int initialPosition, int targetX, int targetY)
        {      
            int moves = Math.Abs(targetY - initialPosition + 1);
            var position = string.Format("{0}|{1}", targetX, targetY);

            if (!ParkingLot.Contains(position))
            {
                ParkingLot.Add(position);
                moves += targetX;
                Console.WriteLine(moves);
                return;
            }

            var minPosition = int.MaxValue;
            List<int> possiblePOsitions = new List<int>();
            bool isFound = false;

            for (int col = 1; col < colsCount; col++)
            {
                var searchedPosition = string.Format("{0}|{1}", col, targetY);

                if (!ParkingLot.Contains(searchedPosition))
                {
                    var distance = Math.Abs(targetX - col);

                    if (distance < minPosition)
                    {
                        minPosition = col;
                        possiblePOsitions.Clear();
                        possiblePOsitions.Add(col);
                        isFound = true;
                    }
                    else if (distance == minPosition)
                    {
                        possiblePOsitions.Add(col);
                    }
                }
            }


            if (isFound)
            {
                position = string.Format("{0}|{1}", possiblePOsitions.First(), targetY);
                ParkingLot.Add(position);
                moves += possiblePOsitions.Min();
                Console.WriteLine(moves);
            }
            else
            {
                Console.WriteLine("Row {0} full", targetY);             
            }
        }
    
    }
}

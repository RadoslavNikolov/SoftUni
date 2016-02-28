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
        private static readonly HashSet<string> ParkingLot = new HashSet<string>();
        private static int rowsCount;
        private static int colsCount;

        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var tokens = Regex.Split(inputLine, @"\s+").Select(int.Parse).ToArray();
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
                var initialPosition = tokens[0];
                var x = tokens[1];
                var y = tokens[2];

                DoPark(initialPosition, x, y);                    
            }
        }

        private static void DoPark(int initialPosition, int x, int y)
        {              
            var position = string.Format("{0}|{1}", x, y);
            int moves = Math.Abs(initialPosition - x) + 1;

            if (!ParkingLot.Contains(position))
            {
                ParkingLot.Add(position);
                moves += y;
                Console.WriteLine(moves);
                return;
            }

            var minPosition = int.MaxValue;
            List<int> possiblePositions = new List<int>();
            bool isFound = false;

            for (int col = 1; col < colsCount; col++)
            {
                var searchedPosition = string.Format("{0}|{1}", x, col);

                if (!ParkingLot.Contains(searchedPosition))
                {
                    var distance = Math.Abs(y - col);

                    if (distance < minPosition)
                    {
                        minPosition = distance;
                        possiblePositions.Clear();
                        possiblePositions.Add(col);
                        isFound = true;
                    }
                    else if (distance == minPosition)
                    {
                        possiblePositions.Add(col);
                        isFound = true;
                    }
                }
            }

            if (isFound)
            {
                position = string.Format("{0}|{1}", x, possiblePositions.Min());
                ParkingLot.Add(position);
                moves += possiblePositions.Min();
                Console.WriteLine(moves);
            }
            else
            {
                Console.WriteLine("Row {0} full", x);             
            }
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_System
{
    public class ParkingSystemMain
    {
        private static readonly HashSet<string> ParkingLot = new HashSet<string>();
        private static int rowsCount;
        private static int colsCount;

        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim();
            var tokens = inputLine.Split(' ').Select(int.Parse).ToArray();
            rowsCount = tokens[0];
            colsCount = tokens[1];

            while (true)
            {
                inputLine = Console.ReadLine().Trim();

                if (inputLine.ToLower().Equals("stop"))
                {
                    break;
                }

                tokens = inputLine.Split(' ').Select(int.Parse).ToArray();
                var initialPosition = tokens[0];
                var targetX = tokens[2];
                var targetY = tokens[1];

                Console.WriteLine( DoPark(initialPosition, targetX, targetY));          
            }
        }

        private static string DoPark(int initialPosition, int targetX, int targetY)
        {
            int moves = Math.Abs(targetY - initialPosition + 1);
            var position = string.Format("{0}|{1}", targetX, targetY);

            if (!ParkingLot.Contains(position))
            {
                ParkingLot.Add(position);
                moves += targetX;
                return moves.ToString();
            }

            var count = Math.Max(targetX - 1, colsCount - targetX - 1);

            for (int i = 1; i <= count; i++)
            {

                if (targetX - i > 0)
                {
                    position = string.Format("{0}|{1}", targetX - i, targetY);
                    if (!ParkingLot.Contains(position))
                    {
                        ParkingLot.Add(position);
                        moves += targetX - i;
                        return moves.ToString();
                    }
                }

                if (targetX + i < colsCount)
                {
                    position = string.Format("{0}|{1}", targetX + i, targetY);
                    if (!ParkingLot.Contains(position))
                    {
                        ParkingLot.Add(position);
                        moves += targetX + i;
                        return moves.ToString();
                    }
                }
            }

            return string.Format("Row {0} full", targetY);
        }
    }
}

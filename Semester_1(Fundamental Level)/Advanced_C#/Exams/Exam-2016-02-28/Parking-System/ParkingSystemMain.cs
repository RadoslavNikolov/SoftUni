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
                var targetRow = tokens[1];
                var targetCol = tokens[2];

                Console.WriteLine( DoPark(initialPosition, targetRow, targetCol));          
            }
        }

        private static string DoPark(int initialPosition, int targetRow, int targetCol)
        {
            int moves = Math.Abs(targetRow - initialPosition + 1);
            var position = string.Format("{0}|{1}", targetRow, targetCol);

            if (!ParkingLot.Contains(position))
            {
                ParkingLot.Add(position);
                moves += targetCol;
                return moves.ToString();
            }

            var count = Math.Max(targetCol - 1, colsCount - targetCol - 1);

            for (int i = 1; i <= count; i++)
            {

                if (targetCol - i > 0)
                {
                    position = string.Format("{0}|{1}", targetRow, targetCol - i);
                    if (!ParkingLot.Contains(position))
                    {
                        ParkingLot.Add(position);
                        moves += (targetCol - i);
                        return moves.ToString();
                    }
                }

                if (targetCol + i < colsCount)
                {
                    position = string.Format("{0}|{1}", targetRow, targetCol + i);
                    if (!ParkingLot.Contains(position))
                    {
                        ParkingLot.Add(position);
                        moves += (targetCol + i);
                        return moves.ToString();
                    }
                }
            }

            return string.Format("Row {0} full", targetRow);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Distance_in_Labyrinth
{
    class DistanceInLabyrinth
    {


        static string[,] lab =
        {

                {" ", " ", " ", "*", " ", "*"},

                {" ", "*", " ", "*", " ", "*"},

                {" ", " ", "*", " ", "*", " "},

                {" ", "*", " ", " ", " ", " "},

                {" ", " ", " ", "*", "*", " "},

                {" ", " ", " ", "*", " ", "*"}

        };

        private static string[,] outputLab = new string[lab.GetLength(0), lab.GetLength(1)];

        static string[] path = new string[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;
        private static int minDistance = Int32.MaxValue;
    

        static void FindPath(int row, int col, string direction)
        {

            if ((col < 0) || (row < 0) ||

                  (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))

            {

                // Out of the labyrinth

                return;

            }


            // Append the direction to the path

            path[position] = direction;
            position++;


            // Check if we have found the exit

            if (lab[row, col] == "e")

            {

                PrintPath(path, 1, position - 1);

            }



            if (lab[row, col] == " ")

            {

                // The current cell is free. Mark it as visited

                lab[row, col] = "s";



                // Invoke recursion to explore all possible directions

                FindPath(row, col - 1, "L"); // left

                FindPath(row - 1, col, "U"); // up

                FindPath(row, col + 1, "R"); // right

                FindPath(row + 1, col, "D"); // down



                // Mark back the current cell as free

                lab[row, col] = " ";

            }



            // Remove the direction from the path

            position--;

        }


        static void PrintPath( string[] path, int startPos, int endPos)

        {

            Console.Write("Found path to the exit: ");

            for (int pos = startPos; pos <= endPos; pos++)

            {

                Console.Write(path[pos]);

            }

            Console.WriteLine();
            if ((endPos - startPos + 1) > 0)
            {
                Console.WriteLine(endPos - startPos + 1);
                minDistance = Math.Min(minDistance, (endPos - startPos + 1));
            }
            else
            {
                Console.WriteLine("No path");
            }
            

        }



        private static void Main()
        {
            int positionRow = 2;
            int positionCol = 1;


            Array.Copy(lab, outputLab, lab.Length);

            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row,col] == " ")
                    {
                        Console.WriteLine("Row {0}, Col {1}",row, col);
                        lab[row, col] = "e";
                        minDistance = Int32.MaxValue;
                        FindPath(positionRow, positionCol, "S");
                        Console.WriteLine("Min distance is: {0}", minDistance == Int32.MaxValue ? "No path" : minDistance.ToString());
                        minDistance = Int32.MaxValue;

                    }
                }
                Console.WriteLine();
            }

            //FindPath(0, 0, "S");


            for (int row = 0; row < outputLab.GetLength(0); row++)
            {
                for (int col = 0; col < outputLab.GetLength(1); col++)
                {
                    Console.Write(outputLab[row, col]);
                }
                Console.WriteLine();
            }


        }
    }
}

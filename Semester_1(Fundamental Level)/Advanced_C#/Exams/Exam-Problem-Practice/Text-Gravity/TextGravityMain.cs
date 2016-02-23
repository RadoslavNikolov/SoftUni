namespace Text_Gravity
{
    using System;
    using System.Reflection.Emit;
    using System.Security;
    using System.Text;

    public class TextGravityMain
    {
        public static void Main()
        {
            var rowLength = int.Parse(Console.ReadLine().Trim());
            var inputLine = Console.ReadLine();

            if (inputLine.Length % rowLength != 0)
            {
                inputLine = inputLine.PadRight((inputLine.Length/rowLength + 1) * rowLength, ' ');
            }

            char[][] matrix = new char[inputLine.Length / rowLength][];
            matrix = FillMatrix(matrix, inputLine, rowLength);

            matrix = ProcessMatrix(matrix);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            var output = new StringBuilder();
            output.Append("<table>");

            foreach (char[] row in matrix)
            {
                output.Append("<tr>");

                foreach (char c in row)
                {
                    output.Append(string.Format("<td>{0}</td>", SecurityElement.Escape(c.ToString())));
                }

                output.Append("</tr>");
            }

            output.Append("</table>");

            Console.WriteLine(output);
        }

        private static char[][] FillMatrix(char[][] matrix, string inputLine, int rowLength)
        {
            for (int i = 0; i < inputLine.Length/rowLength; i++)
            {
                matrix[i] = inputLine.Substring(i*rowLength, rowLength).ToCharArray();
            }

            return matrix;
        }

        private static char[][] ProcessMatrix(char[][] matrix)
        {
            var isMooving = true;

            while (isMooving)
            {
                isMooving = false;
                for (int row = matrix.Length - 2; row >= 0; row--)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] != ' ')
                        {
                            //Move down char
                            for (int newRow = row + 1; newRow < matrix.Length; newRow++)
                            {
                                if (matrix[newRow][col] == ' ')
                                {
                                    //Switch chars
                                    matrix[newRow][col] = matrix[row][col];
                                    matrix[row][col] = ' ';
                                    isMooving = true;
                                }
                            }
                        }
                    }
                }
            }
           
            return matrix;
        }
    }
}

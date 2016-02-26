namespace Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CmdInterpreterMain
    {
        private static List<string> inputList;

        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim();
            inputList = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).ToList();

            while (true)
            {
                inputLine = Console.ReadLine().Trim();

                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                CommandManager(inputLine);
            }

            Console.WriteLine("[{0}]", string.Join(", ", inputList));
        }

        private static void CommandManager(string inputLine)
        {
            var inputTokens = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).ToList();

            var command = inputTokens[0];
            var cmdParams = inputTokens.GetRange(1, inputTokens.Count - 1).ToArray();

            ProcessCommand(command, cmdParams);
        }

        private static void ProcessCommand(string command, string[] cmdParams)
        {
            switch (command.Trim().ToLower())
            {
                case "reverse":
                    ReverseCmd(cmdParams);
                    break;
                case "sort":
                    SortCmd(cmdParams);
                    break;
                case "rollleft":
                    RollShiftCmd(cmdParams, false);
                    break;
                case "rollright":
                    RollShiftCmd(cmdParams, true);
                    break;
                default:
                    break;
            }
        }

        private static void RollShiftCmd(string[] cmdParams, bool right)
        {
            var shiftsCount = int.Parse(cmdParams[0]) % inputList.Count;

            if (shiftsCount < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            if (!right)
            {
                var elementsToMove = inputList
                    .Take(shiftsCount)
                    .ToArray();

                inputList.AddRange(elementsToMove);
                inputList.RemoveRange(0, shiftsCount);
            }
            else
            {
                var elementsToMove = inputList.
                    Skip(inputList.Count - shiftsCount)
                    .Take(shiftsCount)
                    .ToArray();

                inputList.InsertRange(0, elementsToMove);
                inputList.RemoveRange(inputList.Count - shiftsCount, shiftsCount);
            }
        }

        private static void SortCmd(string[] cmdParams)
        {
            var start = int.Parse(cmdParams[1]);
            var count = int.Parse(cmdParams[3]);

            if (!ValidateParams(start, count))
            {
                return;
            }

            var resultList = new List<string>();
            resultList.AddRange(inputList.GetRange(0, start));

            var reversedList = inputList.GetRange(start, count);
            reversedList.Sort();
            resultList.AddRange(reversedList);
            resultList.AddRange(inputList.GetRange((start + count), inputList.Count - (start + count)));

            inputList = resultList;
        }

        private static void ReverseCmd(string[] cmdParams)
        {
            var start = int.Parse(cmdParams[1]);
            var count = int.Parse(cmdParams[3]);

            if (!ValidateParams(start, count))
            {
                return;
            }

            var resultList = new List<string>();
            resultList.AddRange(inputList.GetRange(0, start));

            var reversedList = inputList.GetRange(start, count);
            reversedList.Reverse();
            resultList.AddRange(reversedList);
            resultList.AddRange(inputList.GetRange((start + count), inputList.Count - (start + count)));

            inputList = resultList;
        }

        public static bool ValidateParams(int start, int count)
        {
            if (start < 0 || start >= inputList.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }

            if (start + count < 0 || start + count > inputList.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }

            return true;
        }
    }
}

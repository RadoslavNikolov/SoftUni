namespace SeqOfEqualStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EqualStringsProgram
    {
        static void Main()
        {
            const string exitCommand = "exit";

            while (true)
            {
                Console.Write("Enter array of floating numbers, separated by space or \"{0}\" for exiting the program: ", exitCommand);
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                var inputStringArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var seqArray = inputStringArray
                    .Select((n, i) => new {Value = n, Index = i})
                    //.OrderBy(s => s.Value)  //Order new selection by condition
                    .Select((o, i) => new {Value = o.Value, Diff = i - o.Index})
                    .GroupBy(s => new {s.Value, s.Diff})
                    .ToList();

                seqArray.ForEach(group =>
                {
                    Console.WriteLine(string.Join(" ", group.Select(x => x.Value)));
                });
            }
        }
    }
}

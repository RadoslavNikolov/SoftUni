namespace Count_Symbols
{
    using System;
    using System.Collections;
    using System.Linq;

    public class CountSymbolsProgram
    {
        public static void Main()
        {
            Console.Write("Enter string or\"exit\": ");
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            //var result = inputLine
            //    .GroupBy(c => c)
            //    .Select(g => new
            //    {
            //        Letter = g.Key,
            //        Count = g.Count()
            //    })
            //    .OrderBy(g => g.Letter)
            //    .ToList();

            //foreach (var group in result)
            //{
            //    Console.WriteLine("{0}: {1} time/s", group.Letter, group.Count);

            //}

            //Or more incomprehensible
            inputLine
                .GroupBy(c => c)
                .Select(g => new
                {
                    Letter = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.Letter)
                .ToList()
                .ForEach(group =>
                {
                    Console.WriteLine("{0}: {1} time/s", group.Letter, group.Count);
                });
        }
    }
}

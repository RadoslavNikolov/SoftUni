namespace Vladkos_Notebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class VladkosNotebookMain
    {
        public static readonly ISet<Sheet> SheetsData  = new SortedSet<Sheet>();

        public static void Main()
        {
            var countOfLines = 0;
            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine.ToLower().Equals("end") || ++countOfLines > 150)
                {
                    break;
                }

                try
                {
                    ProcessInputLine(inputLine);
                }
                catch (ArgumentException ex)
                {
                    continue;
                }
            }

            PrintSheetsData();

        }

        private static void PrintSheetsData()
        {
            var sheets = SheetsData.Where(sh => sh.Age != default(int) && sh.HostName != default(string));

            if (sheets.Any())
            {
                foreach (Sheet sheet in sheets)
                {
                    Console.WriteLine(sheet);
                }
            }
            else
            {
                Console.WriteLine("No data recovered.");
            }
        }

        private static void ProcessInputLine(string inputLine)
        {
            var inputTokens = inputLine.Split('|');
            if (inputTokens.Length != 3)
            {
                return;
            }

            var color = inputTokens[0].Trim();
            var propName = inputTokens[1].Trim();
            var propValue = inputTokens[2].Trim();

            Sheet currentSheet = GetSheetByColor(color);

            switch (propName.ToLower())
            {
                case "age" :
                    currentSheet.Age = int.Parse(propValue);
                    break;
                case "win": 
                    currentSheet.AddMatch(new Match(propValue, propName));
                    break;
                case "loss":
                    currentSheet.AddMatch(new Match(propValue, propName));
                    break;
                case "name":
                    currentSheet.HostName = propValue;
                    break;
                default: break;
            }
        }

        private static Sheet GetSheetByColor(string color)
        {
            var sheet = SheetsData.FirstOrDefault(sh => sh.Color == color);

            if (sheet == default(Sheet))
            {
                sheet = new Sheet(color);
                SheetsData.Add(sheet);
            }

            return sheet;
        }
    }


    public class Sheet : IComparable<Sheet>
    {
        private readonly IList<Match> matches;
        private string hostName;
        private string color;
        private int age;
  
        public Sheet(string color)
        {
            this.Color = color;
            this.matches = new List<Match>();
        }

        public string HostName
        {
            get { return this.hostName; }
            set
            {
                if (Regex.Matches(value, "([a-zA-z\\s]{1,50})(.*)").Count > 1)
                {
                    throw new ArgumentException("Invalid hostname");
                }

                this.hostName = value;
            }
        }

        public string Color
        {
            get { return this.color; }
            private set
            {
                if (Regex.Matches(value, "([a-zA-z\\s]{1,50})(.*)").Count > 1)
                {
                    throw new ArgumentException("Invalid hostname");
                }

                this.color = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("Invalid age");
                }

                this.age = value;
            }
        }

        public IEnumerable<Match> Matches
        {
            get { return this.matches; }
        }

        public void AddMatch(Match match)
        {
            this.matches.Add(match);
        }

        public double Rank
        {
            get
            {
                double rank =
                    (double)(this.Matches.Count(m => m.MatchStatus == MatchStatus.win) + 1)/
                    (double)(this.Matches.Count(m => m.MatchStatus == MatchStatus.loss) + 1);

                return rank;
            }
        }

        public int CompareTo(Sheet other)
        {
            return String.Compare(this.Color, other.Color, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("Color: {0}", this.Color));
            output.AppendLine(string.Format("-age: {0}", this.Age));
            output.AppendLine(string.Format("-name: {0}", this.HostName));

            var opponentsList = this.matches.OrderBy(m => m.OpponentName, StringComparer.Ordinal).Select(m => m.OpponentName);
            output.AppendLine(string.Format("-opponents: {0}",
                opponentsList.Any() ? string.Join(", ", opponentsList) : "(empty)"));

            output.AppendLine(string.Format("-rank: {0:F2}", this.Rank));
            return output.ToString().Trim();
        }
    }

    public class Match
    {
        public Match(string opponentName, string matchStatus)
        {
            this.OpponentName = opponentName;
            this.MatchStatus = (MatchStatus)Enum.Parse(typeof(MatchStatus), matchStatus);
        }

        public string HostName { get; private set; }

        public string OpponentName { get; private set; }

        public MatchStatus MatchStatus { get; private set; }
    }

    public enum MatchStatus
    {
        win,
        loss
    }
}

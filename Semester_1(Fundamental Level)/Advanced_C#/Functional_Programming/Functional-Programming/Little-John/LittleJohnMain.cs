namespace Little_John
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LittleJohnMain
    {
        private static readonly IList<string> inputList = new List<string>();

        public static void Main()
        {
            for (int i = 0; i < 4; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            ProcessInput();
        }

        private static void ProcessInput()
        {
            var smallArrowPattern = "(>[-]{5}>)";
            var mediumArrowPattern = "(>>[-]{5}>)";
            var bigArrowPattern = "(>>>[-]{5}>>)";
            var smallCount = 0;
            var mediCount = 0;
            var bigCount = 0;

            for (int i = 0; i < inputList.Count; i++)
            {
                var line = inputList[i];

                bigCount += Regex.Matches(line, bigArrowPattern).Count;
                line = Regex.Replace(line, bigArrowPattern, " ");

                mediCount += Regex.Matches(line, mediumArrowPattern).Count;
                line = Regex.Replace(line, mediumArrowPattern, " ");

                smallCount += Regex.Matches(line, smallArrowPattern).Count;
                line = Regex.Replace(line, smallArrowPattern, " ");
            }

            var decNum = int.Parse(string.Format("{0}{1}{2}", smallCount, mediCount, bigCount));
            var binNum = Convert.ToString(decNum, 2);
            binNum += string.Join("", binNum.Reverse());
            decNum = Convert.ToInt32(binNum, 2);

            Console.WriteLine(decNum);
        }
    }
}

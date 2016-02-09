namespace JoinLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClassExercise;

    public class JoinArraysProgram
    {
        public static void Main()
        {
            const string exitCommand = "exit";
            const string joinCommand = "join";

            Console.WriteLine("Enter \"{0}\" for exiting the program", exitCommand);
            var count = 0;

            IList<IList<int>> listsToJoin = new List<IList<int>>();
            IList<int> joinedList = new List<int>();

            while (true)
            {
                count++;
                Console.Write("Enter {0} list of integer numbers or \"{1}\" to join lists: ", count, joinCommand);
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                if (inputLine.ToLower().Equals(joinCommand))
                {
                    JoinList(listsToJoin, joinedList);
                    var sortedArray = Sorters<int>.BubbleSort(joinedList.ToArray());
                    Console.WriteLine("Joined list is: {0}", sortedArray.Length > 0 ? string.Join(" ", sortedArray) : "nothing to join");

                    Environment.Exit(0);
                }

                var newList = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                listsToJoin.Add(newList);
            }
        }


        private static void JoinList(IList<IList<int>> listsToJoin, IList<int> resultList)
        {
            listsToJoin.ToList().ForEach(list =>
            {
                list.ToList().ForEach(item =>
                {
                    if (!resultList.Contains(item))
                    {
                        resultList.Add(item);
                    }
                });
            });
        }
    }
}

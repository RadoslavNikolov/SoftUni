namespace StudentsGroup
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    public class StudentsGroupMain
    {
        public static void Main()
        {
            var db = StudentsDB.Instance;

            var results = db.Students
                .GroupBy(s => s.GroupNumber)
                .OrderBy(g => g.Key);

            foreach (var grouping in results)
            {
                Console.WriteLine("Group: {0}", grouping.Key);
                foreach (var student in grouping)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}

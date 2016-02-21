namespace ExcellentStudents
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class ExcellentStudentsMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var results = db.Students.Where(s => s.Marks.Contains(6));

            foreach (var student in results)
            {
                Console.WriteLine(student);
            }
        }
    }
}

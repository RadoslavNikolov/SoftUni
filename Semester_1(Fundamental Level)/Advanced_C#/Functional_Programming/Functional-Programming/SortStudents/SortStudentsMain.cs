namespace SortStudents
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class SortStudentsMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var result = db.Students.OrderByDescending(s => s.FirstName)
                .ThenByDescending(s => s.LastName);

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }
}

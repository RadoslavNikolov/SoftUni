namespace WeakStudents
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class WeakStudentsMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var results = db.Students.Where(s => s.Marks.Count(m => m == 2) == 2);

            foreach (var student in results)
            {
                Console.WriteLine(student);
            }
        }
    }
}

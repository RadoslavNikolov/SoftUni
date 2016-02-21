namespace StudentByNames
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class StudentByNamesMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var result = db.Students.Where(s => s.FirstName.CompareTo(s.LastName) < 0);

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }
}

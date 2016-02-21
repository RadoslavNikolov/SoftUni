namespace StudentsByGroup
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class StudentsByGroupMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var result = db.Students.Where(s => s.GroupNumber == 2);

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }
}

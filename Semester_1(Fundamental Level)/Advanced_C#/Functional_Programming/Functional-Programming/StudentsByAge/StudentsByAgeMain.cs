namespace StudentsByAge
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class StudentsByAgeMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var results = db.Students.Where(s => s.Age >= 18 && s.Age <= 24)
                .Select(s => new
                {
                    s.FirstName,
                    s.LastName,
                    s.Age
                });

            foreach (var student in results)
            {
                Console.WriteLine("First name: {0},  Last name: {1},  Age: {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}

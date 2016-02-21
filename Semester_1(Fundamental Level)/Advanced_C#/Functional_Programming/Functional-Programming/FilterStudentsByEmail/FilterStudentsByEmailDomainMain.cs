namespace FilterStudentsByEmail
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class FilterStudentsByEmailDomainMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var result = db.Students.Where(s => s.Email.ToLower().EndsWith("abv.bg"));

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }
}

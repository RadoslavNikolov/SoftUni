namespace FilterStudentsByPhone
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    class FilterStudentsByPhoneMain
    {
        static void Main()
        {
            var db = StudentsDB.Instance;

            var result = db.Students.Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592")
                                                || s.Phone.StartsWith("+359 2"));

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
        }
    }
}

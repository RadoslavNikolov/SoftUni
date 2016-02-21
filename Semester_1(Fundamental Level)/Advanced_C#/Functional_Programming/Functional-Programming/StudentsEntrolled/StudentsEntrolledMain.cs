namespace StudentsEntrolled
{
    using System;
    using System.Linq;
    using Functional_Programming.Data;

    public class StudentsEntrolledMain
    {
        public static void Main()
        {
            var db = StudentsDB.Instance;

            var results = db.Students.Where(s =>
            {
                var facNumStr = s.FacultyNumber.ToString();

                return facNumStr[4].Equals('1') && facNumStr[5].Equals('4');
            });

            foreach (var student in results)
            {
                Console.WriteLine(student);
            }
        }
    }
}

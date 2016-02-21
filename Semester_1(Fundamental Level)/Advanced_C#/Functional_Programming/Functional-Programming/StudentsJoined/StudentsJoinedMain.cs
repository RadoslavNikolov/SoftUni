namespace StudentsJoined
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Functional_Programming.Data;
    using Functional_Programming.Models;

    public class StudentsJoinedMain
    {
        public static void Main()
        {
            var db = StudentsDB.Instance;

            var studentSpecList = new List<StudentSpeciality>()
            {
                new StudentSpeciality("Web Developer", 35251455),
                new StudentSpeciality("Web Developer", 22241556),
                new StudentSpeciality("PHP Developer", 95541555),
                new StudentSpeciality("PHP Developer", 29251455),
                new StudentSpeciality("QA Engineer", 38991565),
                new StudentSpeciality("Web Developer", 44251555),
                new StudentSpeciality("PHP Developer", 19251519)
            };

            var results =
                from student in db.Students
                join entry in studentSpecList
                    on student.FacultyNumber equals entry.FacultyNumber
                select new
                {
                    Name = student.FirstName + "  " + student.LastName,
                    FacNum = student.FacultyNumber,
                    Speciality = entry.SpecialityName
                };

            foreach (var entry in results)
            {
                Console.WriteLine("{0}  --  {1}  --  {2}", entry.Name, entry.FacNum, entry.Speciality);
            }
        }
    }
}

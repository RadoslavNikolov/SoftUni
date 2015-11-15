namespace Students_and_Courses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class StudentsAndCourses
    {
        static void Main()
        {
            const Int32 BufferSize = 128;
            string filePath = "../../../Students.txt";
            var studentsAndCourses = new SortedDictionary<string, SortedSet<Person>>();

            using (var fileStream = File.OpenRead(filePath))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var tokens = line.Split('|');

                        string firstName = tokens[0].Trim();
                        string lastName = tokens[1].Trim();
                        string course = tokens[2].Trim();

                        var newPerson = new Person()
                        {
                            FirstName = firstName,
                            LastName = lastName
                        };

                        if (!studentsAndCourses.ContainsKey(course))
                        {
                            
                            studentsAndCourses[course] = new SortedSet<Person>();
                        }

                        studentsAndCourses[course].Add(newPerson);
                    }
                }
            }

            foreach (KeyValuePair<string, SortedSet<Person>> studentsAndCourse in studentsAndCourses)
            {
                string output = studentsAndCourse.Key + ": " + String.Join(", ", studentsAndCourse.Value);

                Console.WriteLine(output);
            }
        }
    }
}

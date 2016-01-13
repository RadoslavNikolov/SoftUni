using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    using Interfaces;
    using Models;

    class CoursesExamples
    {
        static void Main()
        {
            var courses = new List<ICourse>();

            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);

            //Test Polymorphism
            courses.Add(localCourse);
            courses.Add(offsiteCourse);
            courses.ForEach(c => 
            {
                Console.WriteLine(String.Format("I am {0}", c.GetType().Name));
            });
            courses.ForEach(Console.WriteLine);
            
        }
    }
}

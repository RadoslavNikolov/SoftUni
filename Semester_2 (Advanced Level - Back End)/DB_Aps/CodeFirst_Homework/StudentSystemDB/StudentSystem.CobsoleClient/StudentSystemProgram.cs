using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.CobsoleClient
{
    using System.Diagnostics.CodeAnalysis;
    using Data;

    class StudentSystemProgram
    {

        static void Main(string[] args)
        {
            var context = new StudentSystemContext();

            ////Problem 3 - 1
            //var students = context.Students.Select(s => new
            //{
            //    s.Name, 
            //    Homeworks = s.Homeworks.ToList()
            //}).ToList();

            //students.ForEach(s =>
            //{
            //    Console.WriteLine("Name: {0}", s.Name);
            //    s.Homeworks.ForEach(h => Console.WriteLine("    {0}   {1}    {2}", h.Content, h.ContentType, h.SubmissionDate));
            //});


            ////Problem 3 - 2
            //var courses = context.Courses.Select(c => new
            //{
            //    c.Name,
            //    c.Description, 
            //    Resouces = c.Resources.ToList()
            //}).ToList();

            //courses.ForEach(c =>
            //{
            //    Console.WriteLine("{0}   {1}", c.Name, c.Description);
            //    c.Resouces.ForEach(r => Console.WriteLine("     {0}   {1}   {2}", r.Name, r.ResourseType, r.Url));
            //});

            ////Problem 3  -  3
            //var courses = context.Courses
            //    .Where(c => c.Resources.Count > 5)
            //    .OrderByDescending(c => c.Resources.Count)
            //    .ThenByDescending(c => c.StartDate)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.Resources.Count
            //    }).ToList();

            //if (courses.Count > 0)
            //{
            //    courses.ForEach(c =>
            //    {
            //        Console.WriteLine("{0}   {1}", c.Name, c.Count);
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("There is no courses with more then 5 resources!");
            //}

            ////Problem 3  -  4
            //var givenDate = DateTime.Now.AddDays(10);
            //var courses = context.Courses
            //    .Where(c => c.EndDate >= givenDate)
            //    .Select(c => new
            //    {
            //        Name = c.Name,
            //        StartDate = c.StartDate,
            //        EndDate = c.EndDate,
            //        StudentsEnrolled = c.Students.Count
            //    }).ToList();

            //if (courses.Count > 0)
            //{
            //    courses.ForEach(c =>
            //    {
            //        Console.WriteLine("Name:{0}  | Start Date: {1}  |   End Date: {2}  |  Duration in days: {3}  |   Student Enrolled: {4} ", 
            //            c.Name, c.StartDate, c.EndDate, (c.EndDate - c.StartDate).TotalDays , c.StudentsEnrolled);
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("There is no courses with such a dependencies");
            //}


            //Problem 3  -  5
            var students = context.Students
                .Select(s => new
                {
                    s.Name,
                    s.Courses.Count,
                    Total = s.Courses.Select(c => c.Price).ToList().Sum(),
                    Avg = s.Courses.Select(c => c.Price).ToList().Average()
                })
                .OrderByDescending(s => s.Total)
                .ThenByDescending(s => s.Count)
                .ThenBy(s => s.Name).ToList();

            students.ForEach(s =>
            {
                Console.WriteLine("Name: {0}  |  NumOfCourses: {1}  |  Total Price: {2}  |  Average price: {3}", s.Name, s.Count, s.Total, s.Avg);
            });


        }

    }
}

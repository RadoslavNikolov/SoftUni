namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {

            if (context.Students.Count() == 0)
            {
                context.Students.AddOrUpdate(s => s.Name,
                 new Student() { Name = "Pesho", RegisteredOn = DateTime.Now, BirthDay = DateTime.Now.AddMonths(2)},
                 new Student() { Name = "Gosho", PhoneNumber = "088874555555", RegisteredOn = DateTime.Now.AddDays(2), BirthDay = DateTime.Now.AddMonths(8)},
                 new Student() { Name = "Vanka", RegisteredOn = DateTime.Now.AddHours(8), BirthDay = DateTime.Now.AddMonths(4)}
                 );
            }

            if (context.Courses.Count() == 0)
            {
               context.Courses.AddOrUpdate(c => c.Name,
                new Course() { Name = "PHP", Description = "mega cool", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Price = 500},
                new Course() { Name = "C#", Description = "cool", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Price = 300},
                new Course() { Name = "JS", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Price = 600},
                new Course() { Name = "OOP", Description = "dirty", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6), Price = 1000}              
                ); 
            }

            if (context.Resources.Count() == 0)
            {
                context.Resources.AddOrUpdate(r => r.Name,
                 new Resource() { Name = "Res1", ResourseType = ResourseType.Other, Url = "sdssd", CourseId = 1},
                 new Resource() { Name = "Res2", ResourseType = ResourseType.Document, Url = "sdfsdfdsfdsdssd", CourseId = 2},
                 new Resource() { Name = "Res3", ResourseType = ResourseType.Presentation, Url = "sddfdfdssd", CourseId = 3},
                 new Resource() { Name = "Res4", ResourseType = ResourseType.Video, Url = "sddfdfssd", CourseId = 4}
                 );
            }


            if (context.Homeworks.Count() == 0)
            {
                context.Homeworks.AddOrUpdate(h => h.Content,
                 new Homework() { Content = "homework1", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 1, CourseId = 1},
                 new Homework() { Content = "homework2", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 1, CourseId = 3 },
                 new Homework() { Content = "homework3", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 2, CourseId = 1 },
                 new Homework() { Content = "homework4", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 2, CourseId = 3 },
                 new Homework() { Content = "homework5", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 2, CourseId = 4 },
                 new Homework() { Content = "homework6", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 3, CourseId = 2 },
                 new Homework() { Content = "homework7", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 3, CourseId = 3 },
                 new Homework() { Content = "homework8", ContentType = ContentType.Application, SubmissionDate = DateTime.Now.AddDays(8), StudentId = 3, CourseId = 4 }
                 );
            }

  
            //context.Students.FirstOrDefault(s => s.Name == "Pesho")
            //    .Courses.Add(context.Courses.FirstOrDefault(c => c.Name == "PHP"));
            //context.Students.FirstOrDefault(s => s.Name == "Pesho")
            //    .Courses.Add(context.Courses.FirstOrDefault(c => c.Name == "C#"));
            //context.Students.FirstOrDefault(s => s.Name == "Gosho")
            //    .Courses.Add(context.Courses.FirstOrDefault(c => c.Name == "PHP"));
            //context.Students.FirstOrDefault(s => s.Name == "Gosho")
            //    .Courses.Add(context.Courses.FirstOrDefault(c => c.Name == "C#"));
            //context.Students.FirstOrDefault(s => s.Name == "Gosho")
            //    .Courses.Add(context.Courses.FirstOrDefault(c => c.Name == "OOP"));
            //context.Students.FirstOrDefault(s => s.Name == "Vanka")
            //    .Courses.Add(context.Courses.FirstOrDefault(c => c.Name == "JS"));
            context.SaveChanges();
        }
    }
}

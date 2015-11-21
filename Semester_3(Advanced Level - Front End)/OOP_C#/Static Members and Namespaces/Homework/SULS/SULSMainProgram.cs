namespace SULS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    class SULSMainProgram
    {
        static void Main()
        {
            ////Test this!!!!
            
            //var lectureTeam = new List<Person>()
            //{
            //    new SeniorTrainer("Acho", "Achov", 35),
            //    new SeniorTrainer("Dancho", "Danchov", 25),
            //    new Trainer("Eduard", "Edov", 24)
            //};

            //lectureTeam.ForEach(Console.WriteLine);

            //Trainer edo = (Trainer) lectureTeam.First(p => p.FristName == "Eduard");
            //edo.CreateCourses("C#", "Java");           
            //lectureTeam.ForEach(Console.WriteLine);

            //Trainer someTrainer = (Trainer) lectureTeam.First(t => t.GetType().Name.ToLower() == "trainer");
            //someTrainer.CreateCourses("OOP", "MVC");
            //lectureTeam.ForEach(Console.WriteLine);

            //SeniorTrainer someSeniorTrainer = (SeniorTrainer)lectureTeam.First(t => t.GetType().Name.ToLower() == "seniortrainer");
            //someSeniorTrainer.DeleteCourses("OOP", "C#");

            var studentsList = new List<Student>();


            OnsideSudent onsideStudent = new OnsideSudent("Vancho", "Vanchov", 25, "125548664", 5.80, "C#");
            onsideStudent.Visits.Add(new Visit(DateTime.Now));
            onsideStudent.Visits.Add(new Visit(DateTime.Now.AddDays(2)));
            studentsList.Add(onsideStudent);

            onsideStudent = new OnsideSudent("Pencho", "Penchev", 22, "123355444", 5.50, "C#");
            onsideStudent.Visits.Add(new Visit(DateTime.Now));
            studentsList.Add(onsideStudent);

            CurrentStudent curretStudent = new CurrentStudent("Penka", "Penkova", 28, "125547564", 4.85, "Java");
            studentsList.Add(curretStudent);

            var student = new Student("Mitko", "Mitkov", 32, "1232145444", 5.0);
            studentsList.Add(student);

            DropoutStudent dropoutStudent = new DropoutStudent("Minka", "Minkova", 26, "544233545", 2.20);
            dropoutStudent.DropoutReason = "Weak average grade";
            studentsList.Add(dropoutStudent);

            studentsList.Where(s => s is CurrentStudent)
                .OrderBy(s => s.AvgGrade)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine(new string('-', Console.BufferWidth));
            studentsList.Where(s => s is DropoutStudent)
                .OrderBy(s => s.StudentNumber)
                .OfType<DropoutStudent>()
                .ToList()
                .ForEach(s => s.Reapply());

        }
    }
}

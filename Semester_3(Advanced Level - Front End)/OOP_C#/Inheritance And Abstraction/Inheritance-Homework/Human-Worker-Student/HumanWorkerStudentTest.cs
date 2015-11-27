namespace Human_Worker_Student
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    class HumanWorkerStudentTest
    {
        static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Stu1FN", "Stu1LN", "34a55b11"),
                new Student("Stu2FN", "Stu2LN", "15a55b22"),
                new Student("Stu3FN", "Stu3LN", "56a55b33"),
                new Student("Stu4FN", "Stu4LN", "5455b44"),
                new Student("Stu5FN", "Stu5LN", "54a55b55"),
                new Student("Stu6FN", "Stu6LN", "45a55b66"),
                new Student("Stu7FN", "Stu7LN", "35a55b77"),
                new Student("Stu8FN", "Stu8LN", "45a55b88"),
                new Student("Stu9FN", "Stu9LN", "66a55b99"),
                new Student("Stu10FN", "Stu10LN", "65a55b10"),
            };


            var workers = new List<Worker>()
            {
                new Worker("Wor1FN", "Wor1LN"),
                new Worker("Wor2FN", "Wor2LN", 1550),
                new Worker("Wor3FN", "Wor3LN", 620, 6),
                new Worker("Wor4FN", "Wor4LN", 3500, 9),
                new Worker("Wor5FN", "Wor5LN", 1644),
                new Worker("Wor6FN", "Wor6LN", 564,10),
                new Worker("Wor7FN", "Wor7LN", 1545),
                new Worker("Wor8FN", "Wor8LN", 5544,12),
                new Worker("Wor9FN", "Wor9LN", 1244, 8.5f),
                new Worker("Wor10FN", "W10LN"),
            };

            //students.Sort();
            ////or
            students = students.OrderBy(s => s).ToList();

            workers = workers.OrderBy(w => w.WorkSalary).ToList();

            Console.WriteLine(new string('=', Console.BufferWidth));
            students.ForEach(Console.WriteLine);
            Console.WriteLine(new string('=', Console.BufferWidth));
            workers.ForEach(Console.WriteLine);
        }
    }
}

namespace SULS.Models
{
    using System;
    using System.Linq;

    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string fristName, string lastName, int age) : base(fristName, lastName, age)
        {
        }

        internal void DeleteCourses(params string[] courses)
        {
            if (courses.Any())
            {

                foreach (var course in courses)
                {
                Console.WriteLine("Course \"{0}\" was deleted successfully!", course);
                }
            }
        }
    }
}
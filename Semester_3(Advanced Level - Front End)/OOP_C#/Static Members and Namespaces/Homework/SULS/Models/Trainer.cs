namespace SULS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trainer : Person
    {
        private ICollection<Course> courses;  

        public Trainer(string fristName, string lastName, int age) : base(fristName, lastName, age)
        {
            this.courses = new HashSet<Course>();
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        internal void CreateCourses(params string[] courses)
        {
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    this.Courses.Add(new Course(course, DateTime.Now, $"{this.FristName}  {this.lastName}"));
                    Console.WriteLine("Course \"{0}\" was created successfully!", course);
                }
            }
        }


        public override string ToString()
        {
            var result = base.ToString();
            foreach (var course in this.Courses)
            {
                result += "Courses:\n";
                result += course.ToString();
            }
            result += new string('-', Console.BufferWidth);
            return result;
        }
    }
}
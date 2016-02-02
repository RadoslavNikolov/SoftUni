namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {      
        private readonly IList<User> students;
        private readonly IList<Lecture> lesctures;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<User>();
            this.lesctures = new List<Lecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The course name cannot be null or empty");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("The course name must be at least 5 symbols long.");
                }

                this.name = value;
            }
        }

        public ICollection<Lecture> Lectures
        {
            get { return this.lesctures; }
        }

        public ICollection<User> Students
        {
            get { return this.students; }
        }

        public void AddLecture(Lecture lecture)
        {
            this.lesctures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.students.Add(student);
        }
    }
}
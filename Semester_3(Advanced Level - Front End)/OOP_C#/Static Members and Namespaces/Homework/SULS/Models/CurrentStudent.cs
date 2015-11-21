namespace SULS.Models
{
    using System;

    public class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string fristName, string lastName, int age, string studentNumber, double avgGrade, string currentCourse) : base(fristName, lastName, age, studentNumber, avgGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Current course cannot be null or empty");
                }

                this.currentCourse = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"Current course: {this.CurrentCourse}\n";

            return result;
        }
    }
}
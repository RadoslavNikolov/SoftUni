namespace SULS.Models
{
    using System;

    public class Student : Person
    {
        private string studentNumber;
        private double avgGrade;

        public Student(string fristName, string lastName, int age, string studentNumber, double avgGrade) : base(fristName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AvgGrade = avgGrade;
        }

        public string StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student number cannot be null!");
                }
                this.studentNumber = value;
            }
        }

        public double AvgGrade
        {
            get { return this.avgGrade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Inavid average grade!");
                }

                this.avgGrade = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"Student number: {this.StudentNumber} \n";
            result += $"Average grade: {this.AvgGrade} \n";

            return result;
        }
    }
}
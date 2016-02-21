namespace Functional_Programming.Models
{
    using System;
    using System.Security.AccessControl;
    using Enums;

    public class SoftUniStudent
    {
        public SoftUniStudent(int id, string firstName, string lastName, string email, string gender, string studentType, int examResult, int homeworkSent, int homeworkEvaluated, double teamwork, int attendances, double bonus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = (Gender)Enum.Parse(typeof(Gender), gender);
            this.StudentType = (StudentType) Enum.Parse(typeof (StudentType), studentType);
            this.ExamResult = examResult;
            this.HomeworkSent = homeworkSent;
            this.HomeworkEvaluated = homeworkEvaluated;
            this.Teamwork = teamwork;
            this.Attendances = attendances;
            this.Bonus = bonus;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public StudentType StudentType { get; set; }

        public int ExamResult { get; set; }

        public int HomeworkSent { get; set; }

        public int HomeworkEvaluated { get; set; }

        public double Teamwork { get; set; }

        public int Attendances { get; set; }

        public double Bonus { get; set; }
    }
}
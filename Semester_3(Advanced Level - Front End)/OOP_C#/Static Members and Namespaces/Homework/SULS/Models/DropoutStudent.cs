namespace SULS.Models
{
    using System;
    using System.Text;

    public class DropoutStudent : Student
    {

        public DropoutStudent(string fristName, string lastName, int age, string studentNumber, double avgGrade) : base(fristName, lastName, age, studentNumber, avgGrade)
        {
        }

        public string DropoutReason { get; set; }

        public void Reapply()
        {
            var result = this.ToString();
            result += $"Dropout Reason: {this.DropoutReason}\n";
            Console.WriteLine(result);
        }
    }
}
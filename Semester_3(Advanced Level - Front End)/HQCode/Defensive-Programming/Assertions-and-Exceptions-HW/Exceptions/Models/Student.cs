namespace Exceptions_Homework.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Helpers.Exceptions;
    using Helpers.Validators;

    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<Exam> exams;
 
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.InitializeExamsCollection(exams);
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                Validators.ValidateForValidName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                Validators.ValidateForValidName(value);
                this.lastName = value;
            }
        }

        private void InitializeExamsCollection(IList<Exam> inputExams)
        {
            this.exams = inputExams ?? new List<Exam>();

            if (this.exams.Count == 0)
            {
                throw new EmptyCollectionException("Exams collection is empty");
            }
        }

        public IList<ExamResult> GetExams()
        {
            IList<ExamResult> results = new List<ExamResult>();
            //Make deep copy
            for (int i = 0; i < this.exams.Count; i++)
            {
                results.Add(this.exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            double[] examScore = new double[this.exams.Count];
            IList<ExamResult> examResults = this.GetExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = 
                    ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}

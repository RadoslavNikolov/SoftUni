namespace Exceptions_Homework.Models
{
    using Helpers.Exceptions;

    public class ExamResult
    {
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new InvalidGradeException("Grade cannot be negative");
            }

            if (minGrade < 0)
            {
                throw new InvalidCommentException("Min grade cannot be negative");
            }

            if (maxGrade <= minGrade)
            {
                throw new InvalidGradeException("Max grade cannot be smaller than min grade");
            }

            if (string.IsNullOrEmpty(comments))
            {
                throw new InvalidCommentException("Comment cannot be null or empty");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }
    }
}

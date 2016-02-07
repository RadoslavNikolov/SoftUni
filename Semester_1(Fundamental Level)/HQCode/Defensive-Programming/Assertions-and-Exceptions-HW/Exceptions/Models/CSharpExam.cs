namespace Exceptions_Homework.Models
{
    using Helpers.Exceptions;

    public class CSharpExam : Exam
    {
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get { return this.score; }
            private set
            {
                if (value < 0 || 100 < value)
                {
                    throw new InvalidScoreException("Score must be in range [0 - 100]");
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            var result = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");

            return result;
        }
    }
}

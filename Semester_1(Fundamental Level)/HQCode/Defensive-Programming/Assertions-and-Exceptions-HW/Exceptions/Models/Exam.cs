namespace Exceptions_Homework.Models
{
    using Interfaces;

    public abstract class Exam : IExam
    {
        public abstract ExamResult Check();
    }
}

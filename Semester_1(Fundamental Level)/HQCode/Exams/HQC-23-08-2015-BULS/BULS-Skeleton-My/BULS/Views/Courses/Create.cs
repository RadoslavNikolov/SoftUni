namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Models;

    public class Create : ViewAbstract
    {
        public Create(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}
namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Interfaces;
    using Models;
    using Utilities;
    using Utilities.Enums;
    using Utilities.Exceptions;

    public class CoursesController : ControllerAbstract
    {
        public CoursesController(IBangaloreUniversityDate data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourseById(courseId);
            var isInCourse = course.Students.Any(s => s == this.CurrentUser);

            if (!isInCourse)
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourseById(courseId);

            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");                
            }

            course.AddStudent(this.CurrentUser);
            this.CurrentUser.EnrollInCourse(course);

            return this.View(course);
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Lecturer);
            var newCourse = new Course(name);
            this.Data.Courses.Add(newCourse);

            return this.View(newCourse);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Lecturer);
            Course course = this.GetCourseById(courseId);
            course.AddLecture(new Lecture(lectureName));

            return this.View(course);
        }

        private Course GetCourseById(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }
    }
}

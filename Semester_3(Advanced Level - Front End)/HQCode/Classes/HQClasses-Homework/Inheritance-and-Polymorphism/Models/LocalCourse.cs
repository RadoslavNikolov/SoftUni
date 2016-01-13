namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;

    public class LocalCourse : CourseBasic
    {
        public LocalCourse(string name) 
            : base(name)
        {
        }

        public LocalCourse(string name, string teacherName) 
            : base(name, teacherName)
        {
        }

        public LocalCourse(string name, string teacherName, List<string> students) 
            : base(name, teacherName, students)
        {
        }
    }
}

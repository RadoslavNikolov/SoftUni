namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;

    public class OffsiteCourse : CourseBasic
    {
        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public OffsiteCourse(string name, string teacherName, List<string> students)
            : base(name, teacherName, students)
        {
        }      
    }
}

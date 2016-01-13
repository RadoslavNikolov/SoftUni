namespace InheritanceAndPolymorphism.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get;}

        string TeacherName { get; set; }

        string Town { get; set; }

        IEnumerable<string> Students { get; }

        string Lab { get; set; }

        void AddStudent(string student);
    }
}
namespace Functional_Programming.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;

    public class StudentsDB
    {
        private static StudentsDB instance;
        private static readonly ICollection<Student> students = new Collection<Student>();

        private StudentsDB()
        {
        }

        public static StudentsDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentsDB();
                    Helpers.StudentsDbHelper.FillStudentDb(instance);
                }

                return instance;
            }
        }

        public IEnumerable<Student> Students
        {
            get { return students; }
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}
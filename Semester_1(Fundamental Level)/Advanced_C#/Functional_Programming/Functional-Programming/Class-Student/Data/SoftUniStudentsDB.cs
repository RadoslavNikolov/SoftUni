namespace Functional_Programming.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;

    public class SoftUniStudentsDB
    {
        private static SoftUniStudentsDB instance;
        private static readonly ICollection<SoftUniStudent> students = new Collection<SoftUniStudent>();

        private SoftUniStudentsDB()
        {            
        }

        public static SoftUniStudentsDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoftUniStudentsDB();
                }

                return instance;
            }
        }

        public IEnumerable<SoftUniStudent> Students
        {
            get { return students; }
        }

        public void AddStudent(SoftUniStudent student)
        {
            students.Add(student);
        }
    }
}
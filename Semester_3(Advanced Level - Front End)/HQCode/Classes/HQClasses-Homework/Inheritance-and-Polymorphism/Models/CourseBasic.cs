namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Helpers;
    using Interfaces;

    public abstract class CourseBasic : ICourse
    {
        private string name;
        private string teacherName;
        private string town;
        private List<string> students;
        private string lab;

        protected CourseBasic(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        protected CourseBasic(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        protected CourseBasic(string name, string teacherName, List<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.students = students;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validators.ValidateForEmptyString(value);
                this.name = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }
            set
            {
                Validators.ValidateForEmptyString(value);
                this.teacherName = value;
            }
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                Validators.ValidateForEmptyString(value);
                this.town = value;
            }
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                Validators.ValidateForEmptyString(value);
                this.lab = value;
            }
        }

        public IEnumerable<string> Students
        {
            get { return this.students; }
            set { this.students = (List<string>) value; }
        }


        private string GetStudentsAsString()
        {
            if (this.students == null || this.students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }

        public void AddStudent(string student)
        {
            Validators.ValidateForEmptyString(student);
            this.students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("{0}", this.GetType().Name));
            result.Append(" { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
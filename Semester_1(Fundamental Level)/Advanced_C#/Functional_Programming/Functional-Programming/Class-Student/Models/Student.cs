namespace Functional_Programming.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        private static int id;

        static Student()
        {
            id = 0;
        }

        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
        {
            this.Id = ++Student.id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public int FacultyNumber { get; private set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IList<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("=================");
            output.AppendLine(string.Format("{0} {1}  /Age: {2} /FacultetN: {3}", this.FirstName, this.LastName, this.Age, this.FacultyNumber));
            output.AppendLine(string.Format("Phone: {0}  /Email: {1}  /GroupNum: {2}", this.Phone, this.Email,
                this.GroupNumber));
            output.AppendLine(string.Format("Marks: {0}", string.Join(", ", this.Marks)));
            output.AppendLine();

            return output.ToString();
        }
    }
}
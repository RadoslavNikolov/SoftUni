using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SULS
{
    public class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string currentCourse) : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Current course cannot be empty!");
                }
                this.currentCourse = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString() + string.Format("Current course: {0}\n", this.CurrentCourse);
            return result;
        }
    }
}

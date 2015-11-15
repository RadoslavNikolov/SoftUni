using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SULS
{
    public class DropoutStudent : Student
    {
        private string dropoutReason;
        public DropoutStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string dropoutReason) : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Dropout reason cannot be empty!");
                }
                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            string result = this + string.Format("Dropout reason: {0}\n", this.DropoutReason);
            Console.WriteLine(result);
        }
    }
}

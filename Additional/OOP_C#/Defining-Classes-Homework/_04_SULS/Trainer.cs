using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SULS
{
    public class Trainer : Person
    {
        public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Course {0} has been created.\n",courseName);
        }

        public override string ToString()
        {
            string result = base.ToString() + string.Format("Role: {0}\n", this.GetType().Name);
            return result;
        }
    }
}

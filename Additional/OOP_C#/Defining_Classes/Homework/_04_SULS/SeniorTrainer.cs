using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SULS
{
    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("Course {0} has been deleted.\n",courseName);
        }

        public override string ToString()
        {
            string result = base.ToString() + string.Format("Role: {0}\n", this.GetType().Name);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cusotom_LINQ
{
    class LinqProgram
    {
        static void Main()
        {
            var nums = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var filteredCollection = nums.WhereNot(n => n%2 == 0);
            Console.WriteLine(string.Join(", ", filteredCollection));


            var students = new List<Student>()
            {
                new Student("Pesho", 3),
                new Student("Gosho", 2),
                new Student("Mariika", 7),
                new Student("Stamat", 5)
            };

            Console.WriteLine(students.Max(st => st.Grade));
        }
    }
}

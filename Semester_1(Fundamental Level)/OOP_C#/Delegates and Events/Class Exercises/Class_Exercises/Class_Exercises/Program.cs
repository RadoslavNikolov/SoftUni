using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Exercises
{
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main()
        {
            Action<string> print = Console.WriteLine;

            //Tets predicates
            var persons = new List<TestPerson>()
            {
                new TestPerson("Pesho", 25),
                new TestPerson("Ivan", 29),
                new TestPerson("Minka", 32)
            };

            List<TestPerson> result = new List<TestPerson> {persons.MyFirstOrDefault(p => p.Age < 30)};
            result.ForEach(x => print(x.ToString()));
            

           


        }

    }

}

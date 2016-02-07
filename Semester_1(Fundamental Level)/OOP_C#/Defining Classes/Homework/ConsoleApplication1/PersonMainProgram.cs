using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class PersonMainProgram
    {
        static void Main(string[] args)
        {
            var pesho = new Person("Pesho", 20);
            Console.WriteLine(pesho);

            var gosho = new Person("Gosho", 22, "gosho@a.com");
            Console.WriteLine(gosho);

            pesho.Email = "pesho@p.com";
            pesho.Print();
        }
    }
}

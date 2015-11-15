using System;

namespace _01_Persons
{
    class PersonsTest
    {
        static void Main()
        {
            Person pesho = new Person("Pesho", 33);
            Person gosho = new Person("Gosho", 43, "a@b.cd");
            Console.WriteLine(pesho);
            Console.WriteLine(gosho);
        }
    }
}

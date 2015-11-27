namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    class AnimalsTest
    {
        static void Main()
        {
            var dog = new Dog("Sharo", 1.5f, "Shepherd");
            var cat = new Cat("Pussy");
            var frog = new Frog("Froggy", 2.5f);
            var kitten = new Kitten("kitten", 0.8f);
            var tomcat = new Tomcat("Tomcat", 5, "Persian");

            var animal = new List<Animal>();
            animal.Add(dog);
            animal.Add(cat);
            animal.Add(frog);
            animal.Add(kitten);
            animal.Add(tomcat);

            Console.WriteLine(new string('=', Console.BufferWidth));
            animal.ForEach(Console.WriteLine);
            Console.WriteLine(new string('=', Console.BufferWidth));
            animal = animal.OrderBy(a => a.Age).ToList();
            animal.ForEach(Console.WriteLine);
            Console.WriteLine(new string('=', Console.BufferWidth));
            Console.WriteLine("Sum of all animals ages: " + 
                animal.Sum(a => a.Age));
        }
    }
}

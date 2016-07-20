using System;

namespace Serializers_Examples
{
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using Enums;
    using Models;

    class MainProgram
    {
        static void Main(string[] args)
        {
            var location = new Location()
            {
                Label = "Test1",
                Direction = Compass.East
            };

            var person1 = new Person()
            {
                FirstName = "Pencho",
                LastName = "Penchev",
                Age = 40
            };

            var person2 = new Person()
            {
                FirstName = "David",
                LastName = "Jones",
                Age = 38,
                Friends = new Person[] {person1}
            };
            
            Console.WriteLine(CustomSerializing.WriteObject(location, new DataContractJsonSerializer(typeof(Location))));

            Console.WriteLine();

            Console.WriteLine(CustomSerializing.WriteObject(location, new DataContractSerializer(typeof(Location))));

            Console.WriteLine();

            Console.WriteLine(CustomSerializing.WriteObject(person2, new DataContractJsonSerializer(typeof(Person))));

            Console.WriteLine();

            Console.WriteLine(CustomSerializing.WriteObject(person2, new DataContractSerializer(typeof(Person))));
        }

    }
}

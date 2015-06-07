using System;


namespace Person
{
    class Person
    {
        private static int instanceCounter = 0;
        private static DateTime startDate;
        public string Name { get; set; }

        static Person()
        {
            Console.WriteLine("I am static constructor");
            Person.startDate = DateTime.Now;
           
        }

        public Person(string name = null)
        {
            Person.instanceCounter++;
            this.Name = name;
        }

        public int InstanceCounter
        {
            get { return Person.instanceCounter; }
        }

        public DateTime StartDate
        {
            get { return Person.startDate; }
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            Person p = new Person("Radko");
            Console.WriteLine(p.Name);
            Console.WriteLine("Count: " + p.InstanceCounter);
            Console.WriteLine(p.StartDate);
            Person f = new Person("Pesho");
            Console.WriteLine(f.Name);
            Console.WriteLine("Count: " + f.InstanceCounter);
            Console.WriteLine(f.StartDate);
        } 
    }
}

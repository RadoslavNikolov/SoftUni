using System;
using System.Collections.Generic;
  class employeeData
    {
        static void Main()
        {           
            Console.Write("Enter your First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your Age: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.Write("Enter your Gender (m of f): ");
            char gender =Convert.ToChar(Console.ReadLine());
            Console.Write("Enter your personal ID number: ");
            long personalID = long.Parse(Console.ReadLine());
            Console.Write("Enter your unique employee number: ");
            int employeeNumber = int.Parse(Console.ReadLine());
            //printing collected information
            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
            Console.WriteLine(age);
            Console.WriteLine(gender);
            Console.WriteLine(personalID);
            Console.WriteLine(employeeNumber);
        }
    }

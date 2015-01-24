using System;

class firstLastName
{
    static void Main()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine().Trim();
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine().Trim();
        Console.WriteLine("Your full name is: " + firstName.ToUpper() + " " + lastName.ToUpper());
    }
}

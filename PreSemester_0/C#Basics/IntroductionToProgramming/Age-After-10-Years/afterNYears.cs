using System;

class afterNYears
{
    static void Main(string[] args)
    {
        Console.WriteLine("Insert your birthday date (dd.M.yyyy): ");
        string inputStr = Console.ReadLine();
        DateTime birthday = Convert.ToDateTime(inputStr);
        DateTime newDate = DateTime.Now.AddYears(10);
        Console.WriteLine("After 10 years you will be at {0} years", newDate.Year-birthday.Year);
        
    }
}

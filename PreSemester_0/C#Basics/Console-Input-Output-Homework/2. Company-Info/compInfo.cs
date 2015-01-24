using System;

class compInfo
{
    static void Main()
    {
        Console.Write("Company name: ");
        string compName = Console.ReadLine();
        Console.Write("Company address: ");
        string compAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string phoneNum = Console.ReadLine();
        Console.Write("Fax number: ");
        string faxNum = Console.ReadLine();
        Console.Write("Web site: ");
        string web = Console.ReadLine();
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string mamagerLastName = Console.ReadLine();
        Console.Write("Manager age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Manager phone: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine(compName);
        Console.WriteLine("Address: {0}", compAddress);
        Console.WriteLine("Tel. {0}", phoneNum);
        if (faxNum == "")
        {
            Console.WriteLine("Fax: (No Fax)");
        }
        else
        {
            Console.WriteLine("Fax: {0}", faxNum);
        }
        Console.WriteLine("Web site: {0}", web);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3}", managerFirstName, mamagerLastName, age, managerPhone);
    }
}

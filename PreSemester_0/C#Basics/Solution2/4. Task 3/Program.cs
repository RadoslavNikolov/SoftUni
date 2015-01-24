using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of the firm: ");
            string firmName = Console.ReadLine();
            Console.Write("Enter the address of the firm: ");
            string firmAddress = Console.ReadLine();
            Console.Write("Enter the telefon number of the firm: ");
            string firmTelefonNumber = Console.ReadLine();
            Console.Write("Enter the fax number of the firm: ");
            string firmFaxNumber = Console.ReadLine();
            Console.Write("Enter the web site of the firm: ");
            string firmWebSite = Console.ReadLine();
            Console.Write("Enter the first name of the firm manager: ");
            string firmManagerFirstName = Console.ReadLine();
            Console.Write("Enter the last name of the firm manager: ");
            string firmManagerLastName = Console.ReadLine();
            Console.Write("Enter the telefon number of the firm manager: ");
            string firmManagerTelefonNumber = Console.ReadLine();

            Console.Clear();
            Console.WriteLine(firmName);
            Console.WriteLine("Address: {0}",firmAddress);
            Console.WriteLine("Telefon number: {0}", string.IsNullOrEmpty(firmTelefonNumber) ? "No tel.number" : firmTelefonNumber);
            Console.WriteLine("Fax number: {0}", string.IsNullOrEmpty(firmFaxNumber) ? "No Fax number" : firmFaxNumber);
            Console.WriteLine("Web site: {0}", string.IsNullOrEmpty(firmWebSite) ? "No Web site" : firmWebSite);
            Console.WriteLine("Manager name: {0} {1}",firmManagerFirstName,firmManagerLastName);
            Console.WriteLine("Manager tel.nimber: {0}", string.IsNullOrEmpty(firmManagerTelefonNumber) ? "No tel.number" : firmManagerTelefonNumber);
            
        }
    }
}

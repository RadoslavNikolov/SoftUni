using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Model
{
    class ContactsProgram
    {
        static void Main(string[] args)
        {
            var context = new PhonebookModel();
            Console.WriteLine(context.Contacts.Count());
        }
    }
}

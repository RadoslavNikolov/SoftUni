using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_Contacts_from_JSON
{
    using System.IO;
    using System.Web.Script.Serialization;
    using CodeFirst_Model;
    using CodeFirst_Model.Model;

    class ImportContactsFromJSON
    {
        static void Main(string[] args)
        {
            var context = new PhonebookModel();

            var json = File.ReadAllText(@"../../../contacts.json");
            var jsSerialized = new JavaScriptSerializer();
            var parsedData = jsSerialized.Deserialize<IEnumerable<ContactDTO>>(json);

            foreach (var contact in parsedData)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(contact.Name))
                    {
                        throw new ArgumentException("Name is required");
                    }

                    var newContact = new Contact()
                    {
                        Name = contact.Name,
                        Company = contact.Company,
                        Position = contact.Position,
                        Url = contact.Site,
                        Notes = contact.Notes
                    };

                    if (contact.Emails != null)
                    {
                        newContact.Emails = contact.Emails.Select(e => new Email() {EmailAddress = e}).ToList();
                    }

                    if (contact.Phones != null)
                    {
                        newContact.Phones = contact.Phones.Select(p => new Phone() { PhoneNumber = p }).ToList();                      
                    }

                    context.Contacts.Add(newContact);
                    context.SaveChanges();

                    Console.WriteLine("Contact {0} imported", contact.Name);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }

            }
        }
    }
}

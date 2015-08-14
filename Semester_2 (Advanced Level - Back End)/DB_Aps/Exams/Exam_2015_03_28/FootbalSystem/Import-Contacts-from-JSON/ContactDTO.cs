namespace Import_Contacts_from_JSON
{
    using System.Collections.Generic;

    public class ContactDTO
    {
        public string Name { get; set; }

        public string Position { get; set; }
        
        public string Company { get; set; }
        
        public string Site { get; set; }

        public string Notes { get; set; }

        public List<string> Emails { get; set; }

        public List<string> Phones { get; set; }
 
    }
}
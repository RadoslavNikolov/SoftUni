namespace Serializers_Examples.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Person
    {
        [DataMember(Order = 1)]
        public string FirstName { get; set; }

        [DataMember(Order = 2)]
        public string LastName { get; set; }

        [DataMember(Order = 3)]
        public short Age { get; set; }

        [DataMember(Order = 4)]
        public IEnumerable<Person> Friends { get; set; }
    }
}
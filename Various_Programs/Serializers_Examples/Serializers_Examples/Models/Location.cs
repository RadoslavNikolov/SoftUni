namespace Serializers_Examples.Models
{
    using System.Runtime.Serialization;
    using Enums;
    [DataContract]
    public class Location
    {
        [DataMember(Order = 1)]
        public string Label { get; set; }

        [DataMember(Order = 2)]
        public Compass Direction { get; set; } 
    }
}
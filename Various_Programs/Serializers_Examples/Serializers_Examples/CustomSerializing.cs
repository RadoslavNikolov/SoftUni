namespace Serializers_Examples
{
    using System.IO;
    using System.Runtime.Serialization;
    using Models;

    public static class CustomSerializing
    {
        public static object WriteObject(object location, XmlObjectSerializer serializer)
        {
            var stream = new MemoryStream();
            serializer.WriteObject(stream, location);
            stream.Position = 0;

            var streamReader = new StreamReader(stream);

            return streamReader.ReadToEnd();
        }
    }
}
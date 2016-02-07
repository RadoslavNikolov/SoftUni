namespace Exceptions_Homework.Helpers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EmptyCollectionException : Exception
    {
        public EmptyCollectionException()
        {
        }

        public EmptyCollectionException(string message) 
            : base(message)
        {
        }

        public EmptyCollectionException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected EmptyCollectionException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
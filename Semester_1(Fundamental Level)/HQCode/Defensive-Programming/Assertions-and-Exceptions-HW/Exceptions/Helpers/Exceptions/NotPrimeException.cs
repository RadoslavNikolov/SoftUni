namespace Exceptions_Homework.Helpers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class NotPrimeException : Exception
    {
        public NotPrimeException()
        {
        }

        public NotPrimeException(string message) 
            : base(message)
        {
        }

        public NotPrimeException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected NotPrimeException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
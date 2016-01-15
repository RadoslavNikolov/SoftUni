namespace Exceptions_Homework.Helpers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidScoreException : Exception
    {
        public InvalidScoreException()
        {
        }

        public InvalidScoreException(string message) 
            : base(message)
        {
        }

        public InvalidScoreException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidScoreException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
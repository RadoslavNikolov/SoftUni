namespace Exceptions_Homework.Helpers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidGradeException : Exception
    {
        public InvalidGradeException()
        {
        }

        public InvalidGradeException(string message) 
            : base(message)
        {
        }

        public InvalidGradeException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidGradeException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
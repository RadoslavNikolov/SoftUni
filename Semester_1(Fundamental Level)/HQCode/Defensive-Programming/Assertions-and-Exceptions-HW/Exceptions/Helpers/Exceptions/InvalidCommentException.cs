namespace Exceptions_Homework.Helpers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidCommentException : Exception
    {
        public InvalidCommentException()
        {
        }

        public InvalidCommentException(string message) 
            : base(message)
        {
        }

        public InvalidCommentException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidCommentException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
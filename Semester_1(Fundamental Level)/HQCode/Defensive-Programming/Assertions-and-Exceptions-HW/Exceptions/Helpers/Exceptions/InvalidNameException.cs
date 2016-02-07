﻿namespace Exceptions_Homework.Helpers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidNameException : Exception
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string message)
            : base(message)
        {
        }

        public InvalidNameException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidNameException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
namespace Huy_Phuong.Custom_Exceptions
{
    using System;
    public class IlegalStartDateException : Exception
    {
        public IlegalStartDateException()
        {
        }

        public IlegalStartDateException(string message)
            : base(message)
        {
        }

        public IlegalStartDateException(string message, Exception inner)
            : base(message, inner)
        {
        } 
    }
}
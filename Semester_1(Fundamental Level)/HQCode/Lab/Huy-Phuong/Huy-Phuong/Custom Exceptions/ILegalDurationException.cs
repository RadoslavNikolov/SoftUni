namespace Huy_Phuong.Custom_Exceptions
{
    using System;
    public class ILegalDurationException : Exception
    {
        public ILegalDurationException()
        {
        }

        public ILegalDurationException(string message)
            : base(message)
        {
        }

        public ILegalDurationException(string message, Exception inner)
            : base(message, inner)
        {
        } 
    }
}
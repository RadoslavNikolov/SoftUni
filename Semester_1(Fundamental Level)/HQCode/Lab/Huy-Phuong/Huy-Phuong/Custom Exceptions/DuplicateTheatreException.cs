namespace Huy_Phuong.Custom_Exceptions
{
    using System;

    public class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException()
        {
        }

        public DuplicateTheatreException(string message)
            : base(message)
        {
        }

        public DuplicateTheatreException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

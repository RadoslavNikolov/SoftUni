namespace Huy_Phuong.Custom_Exceptions
{
    using System;
    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException()
        {
        }

        public TheatreNotFoundException(string message)
            : base(message)
        {
        }

        public TheatreNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
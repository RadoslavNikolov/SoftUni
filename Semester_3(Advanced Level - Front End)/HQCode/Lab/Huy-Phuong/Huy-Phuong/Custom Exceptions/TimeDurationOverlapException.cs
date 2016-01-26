namespace Huy_Phuong.Custom_Exceptions
{
    using System;
    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException()
        {
        }

        public TimeDurationOverlapException(string message)
            : base(message)
        {
        }

        public TimeDurationOverlapException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
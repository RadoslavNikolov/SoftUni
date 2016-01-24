namespace MockingExercise
{
    using System;

    public class TimeProvider : ITimeProvider
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime MinValue
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        public DateTime MaxValue
        {
            get
            {
                return DateTime.MaxValue;
            }
        }
    }
}
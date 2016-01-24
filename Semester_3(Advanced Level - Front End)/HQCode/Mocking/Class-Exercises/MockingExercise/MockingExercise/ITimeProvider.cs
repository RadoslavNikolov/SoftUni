namespace MockingExercise
{
    using System;

    public interface ITimeProvider
    {
        DateTime Now { get;}

        DateTime MinValue { get;}

        DateTime MaxValue { get;}       
    }
}
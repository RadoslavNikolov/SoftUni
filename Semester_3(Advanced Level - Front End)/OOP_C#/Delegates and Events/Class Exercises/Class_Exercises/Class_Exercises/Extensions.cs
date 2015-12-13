namespace Class_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;

    public static class Extensions
    {
        public static T MyFirstOrDefault<T>(this IEnumerable<T> colection, Predicate<T> condition)
        {
            foreach (var item in colection)
            {
                if (condition(item))
                {
                    return item;
                }
            }

            return default(T);
        }
    }
}
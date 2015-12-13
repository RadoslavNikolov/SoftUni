namespace Cusotom_LINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> colection, Func<T, bool> predicate)
        {
            var result = colection.Where(item => !predicate(item)).ToList();

            return result;
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> predicate)
            where TSelector : IComparable
        {
            if (!collection.Any())
            {
                throw  new InvalidOperationException("Collection is empty");
            }

            TSelector max = predicate(collection.First());

            foreach (var item in collection)
            {
                if (max.CompareTo(predicate(item)) < 0)
                {
                    max = predicate(item);
                }
            }

            return max;
        }
         
    }
}
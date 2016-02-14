namespace CombinatoricsLib
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Permutations
    {
        /// <summary>
        /// Gets the permutations without repetition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="length">The length.</param>
        /// <returns>Returns an enumeration of enumerators, one for each permutation of the input.</returns>
        public static IEnumerable<IEnumerable<T>>GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// Gets the permutations with repetition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="length">The length.</param>
        /// <returns>Returns an enumeration of enumerators, one for each permutation of the input.</returns>
        public static IEnumerable<IEnumerable<T>> GetPermutationsWithRepetition<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutationsWithRepetition(list, length - 1)
                .SelectMany(t => list,
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

    }
}

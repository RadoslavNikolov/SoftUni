using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timing_and_Retries
{
    public static class ExtensionMethods
    {
        public static IEnumerable<int> FindNumByCondition(this IEnumerable<int> source, Func<int, bool> predicate)
        {
            foreach (var num in source)
            {
                if (predicate(num))
                {
                    yield return num;
                }
            }
        }

        public static T WithRetry<T>(this Func<T> action)
        {
            var result = default(T);
            int retryCount = 0;
            bool successful = false;

            do
            {
                try
                {
                    result = action();
                    successful = true;
                }
                catch (Exception)
                {
                    retryCount++;
                }

            } while (retryCount < 3 && !successful);

            return result;

        }

        public static Func<TResult> Partial<TParam1, TResult>(this Func<TParam1, TResult> func, TParam1 parameter)
        {
            return () => func(parameter);
        }

        public static Func<TParam1, Func<TResult>> Curry<TParam1, TResult>(this Func<TParam1,TResult> func)
        {
            return parameter => () => func(parameter);
        }

    }
}

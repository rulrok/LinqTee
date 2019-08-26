using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTee
{
    public static class Extension
    {
        public static ITeeable<T> Tee<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var left = new List<T>();
            var right = new List<T>();

            foreach (var item in collection)
            {
                if (predicate(item))
                    left.Add(item);
                else
                    right.Add(item);
            }

            return new TeeContainer<T>(left, right);
        }

        internal static IEnumerable<T> WyeZip<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            var zipCollection = new List<T>();

            using (var lEnumerator = left.GetEnumerator())
            using (var rEnumerator = right.GetEnumerator())
            {
                while (lEnumerator.MoveNext() && rEnumerator.MoveNext())
                {
                    zipCollection.Add(lEnumerator.Current);
                    zipCollection.Add(rEnumerator.Current);
                }

                while (lEnumerator.MoveNext())
                    zipCollection.Add(lEnumerator.Current);

                while (rEnumerator.MoveNext())
                    zipCollection.Add(rEnumerator.Current);
            }

            return zipCollection;
        }
    }
}
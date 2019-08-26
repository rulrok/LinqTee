using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LinqTee.Tests")]

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

        public static ITeeableCollector<T> TeeCollect<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
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
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            
            if (right == null)
                throw new ArgumentNullException(nameof(right));

            var zipCollection = new List<T>();

            using (var lEnumerator = left.GetEnumerator())
            using (var rEnumerator = right.GetEnumerator())
            {
                while (lEnumerator.MoveNext())
                {
                    zipCollection.Add(lEnumerator.Current);
                    if (rEnumerator.MoveNext())
                    {
                        zipCollection.Add(rEnumerator.Current);
                    }
                }

                while (rEnumerator.MoveNext())
                    zipCollection.Add(rEnumerator.Current);
            }

            return zipCollection;
        }
    }
}
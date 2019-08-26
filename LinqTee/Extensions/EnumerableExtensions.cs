using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LinqTee.Contracts;

[assembly: InternalsVisibleTo("LinqTee.Tests")]

namespace LinqTee.Extensions
{
    public static class EnumerableExtensions
    {
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

        public static ITeeable<T> Tee<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return TeeContainer<T>.Create(collection, predicate);
        }
    }
}
using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee.Extensions
{
    public static class EnumerableExtensions
    {
        public static ITeeable<T> Tee<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return TeeContainer<T>.Create(collection, predicate);
        }
    }
}
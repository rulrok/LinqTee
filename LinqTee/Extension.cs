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
    }
}
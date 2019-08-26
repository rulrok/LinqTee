using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqTee
{
    public static class Extension
    {
        public static ITeeable<T> Tee<T>(this IEnumerable<T> collection, Expression<Func<T, bool>> predicate)
        {
            var enumerable = collection.ToList();

            var left = enumerable.Where(predicate.Compile()).ToList();
            var right = enumerable.Except(left).ToList();
            
            return new TeeContainer<T>(left, right);
        }
    }
}
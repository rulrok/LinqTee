using System.Collections.Generic;
using LinqTee.Contracts;
using LinqTee.WyerOperations;

namespace LinqTee.Extensions
{
    public static class ConcatenateExtensions
    {
        public static IEnumerable<T> Concatenate<T>(this IWyeable<T> wyeable)
        {
            return wyeable.OperateWith(new Concatenate<T>());
        }

        public static IEnumerable<T> Zip<T>(this IWyeable<T> wyeable)
        {
            return wyeable.OperateWith(new Zip<T>());
        }
    }
}
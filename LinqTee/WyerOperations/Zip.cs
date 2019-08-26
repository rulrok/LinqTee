using System.Collections.Generic;
using LinqTee.Contracts;
using LinqTee.Extensions;

namespace LinqTee.WyerOperations
{
    public class Zip<T> : IWyeableOperation<T>
    {
        public IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.WyeZip(right);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using LinqTee.Contracts;

namespace LinqTee.WyerOperations
{
    public class Concatenate<T> : IWyeableOperation<T>
    {
        public IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Concat(right);
        }
    }
}
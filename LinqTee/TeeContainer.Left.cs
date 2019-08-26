using System;
using System.Collections.Generic;
using System.Linq;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ILeftCollector<T>
    {
        public ITeeableRemainder<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _left = action(_left);
            return this;
        }


        IRightCollector<T> ILeftCollector<T>.IgnoreLeft()
        {
            return this;
        }

        IRightCollector<T> ILeftCollector<T>.Left(ref IList<T> collection)
        {
            foreach (var left in _left)
                collection.Add(left);

            return this;
        }
    }
}
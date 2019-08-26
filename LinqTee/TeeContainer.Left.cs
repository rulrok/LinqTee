using System;
using System.Collections.Generic;
using System.Linq;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ITeeableSplitter<T>, ITeeableCollector<T>
    {
        public ITeeableRemainder<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _left = action(_left);
            return this;
        }


        ITeeableColectorRemainder<T> ITeeableCollector<T>.LeftCollect(ref IList<T> collection)
        {
            foreach (var left in _left)
                collection.Add(left);

            return this;
        }

        ITeeableColectorRemainder<T> ITeeableCollector<T>.IgnoreLeft()
        {
            return this;
        }
    }
}
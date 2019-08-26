using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ITeeableRemainder<T>, ITeeableColectorRemainder<T>
    {
        public IWyeable<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _right = action(_right);
            return this;
        }

        void ITeeableColectorRemainder<T>.RightCollect(ref IList<T> collection)
        {
            foreach (var right in _right)
            {
                collection.Add(right);
            }
        }

        void ITeeableColectorRemainder<T>.IgnoreRight()
        {
        }
    }
}
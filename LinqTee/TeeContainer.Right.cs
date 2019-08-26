using System;
using System.Collections.Generic;

namespace LinqTee
{
    public partial class TeeContainer<T> : ITeeableRemainder<T>
    {
        public IWyeable<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _right = action(_right);
            return this;
        }
    }
}
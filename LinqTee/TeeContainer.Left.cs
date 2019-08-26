using System;
using System.Collections.Generic;

namespace LinqTee
{
    public partial class TeeContainer<T> : ITeeable<T>
    {
        public ITeeableRemainder<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _left = action(_left);
            return this;
        }
    }
}
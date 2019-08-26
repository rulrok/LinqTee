using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTee
{
    public class TeeContainer<T> : ITeeable<T>, ITeeableRemainder<T>, IWyeable<T>
    {
        private IEnumerable<T> _left;
        private IEnumerable<T> _right;

        internal TeeContainer(IEnumerable<T> left, IEnumerable<T> right)
        {
            _left = left;
            _right = right;
        }

        public ITeeableRemainder<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _left = action(_left);
            return this;
        }

        public IWyeable<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _right = action(_right);
            return this;
        }

        public IEnumerable<T> Wye()
        {
            return _left.Concat(_right);
        }

        public IEnumerable<T> WyeRight()
        {
            return _right.Concat(_left);
        }
    }
}
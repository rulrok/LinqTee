using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqTee
{
    public class TeeContainer<T> : ITeeable<T>, IWyeable<T>
    {
        private IEnumerable<T> _left;
        private IEnumerable<T> _right;

        internal TeeContainer(IEnumerable<T> left, IEnumerable<T> right)
        {
            _left = left;
            _right = right;
        }

        public ITeeable<T> Left(Expression<Func<IEnumerable<T>, IEnumerable<T>>> action)
        {
            _left = action.Compile().Invoke(_left);
            return this;
        }

        public IWyeable<T> Right(Expression<Func<IEnumerable<T>, IEnumerable<T>>> action)
        {
            _right = action.Compile().Invoke(_right);
            return this;
        }

        public IEnumerable<T> Wye()
        {
            return _left.Concat(_right);
        }
    }
}
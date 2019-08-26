using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : IRightProcessor<T>, IRightCollector<T>, IWyeableOperation<T>
    {
        IWyer<T> IRightProcessor<T>.Right(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _right = action(_right);
            return this;
        }

        void IRightCollector<T>.Right(ref IList<T> collection)
        {
            foreach (var right in _right)
            {
                collection.Add(right);
            }
        }

        public IWyeableOperation<T> Wye()
        {
            return this;
        }

        ITeeable<T> IRightSkipper<ITeeable<T>>.IgnoreRight()
        {
            return this;
        }

        IWyer<T> IRightSkipper<IWyer<T>>.IgnoreRight()
        {
            return this;
        }
    }
}
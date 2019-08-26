using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ILeftCollector<T>, ILeftProcessor<T>, IWyeableOperation<T>
    {
        IRightProcessor<T> ILeftProcessor<T>.Left(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _left = action(_left);
            return this;
        }

        IRightCollector<T> ILeftCollector<T>.Left(ref IList<T> collection)
        {
            foreach (var left in _left)
                collection.Add(left);

            return this;
        }

        IRightCollector<T> ILeftSkipper<IRightCollector<T>>.IgnoreLeft()
        {
            return this;
        }

        IRightProcessor<T> ILeftSkipper<IRightProcessor<T>>.IgnoreLeft()
        {
            return this;
        }
    }
}
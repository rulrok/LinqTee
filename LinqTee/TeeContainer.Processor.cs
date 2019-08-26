using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ILeftProcessor<T>, IRightProcessor<T>
    {
        public ILeftProcessor<T> Process()
        {
            return this;
        }

        IRightProcessor<T> ILeftSkipper<IRightProcessor<T>>.IgnoreLeft()
        {
            return this;
        }

        IRightProcessor<T> ILeftProcessor<T>.Left(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _left = action(_left);
            return this;
        }

        IWyer<T> IRightSkipper<IWyer<T>>.IgnoreRight()
        {
            return this;
        }

        IWyer<T> IRightProcessor<T>.Right(Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            _right = action(_right);
            return this;
        }
    }
}
using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ILeftCollector<T>, IRightCollector<T>
    {
        public ILeftCollector<T> Collect()
        {
            return this;
        }

        IRightCollector<T> ILeftCollector<T>.Left(ref IList<T> output)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            foreach (var left in _left)
                output.Add(left);

            return this;
        }

        /// <summary>
        /// Move to right collector
        /// </summary>
        /// <returns></returns>
        IRightCollector<T> ILeftSkipper<IRightCollector<T>>.IgnoreLeft()
        {
            return this;
        }

        void IRightCollector<T>.Right(ref IList<T> output)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            foreach (var right in _right)
                output.Add(right);
        }

        /// <summary>
        /// Move to <see cref="ITeeable{T}"/> base constructor.
        /// </summary>
        /// <returns></returns>
        ITeeable<T> IRightSkipper<ITeeable<T>>.IgnoreRight()
        {
            return this;
        }
    }
}
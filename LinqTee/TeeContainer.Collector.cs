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
        
        ITeeable<T> IRightSkipper<ITeeable<T>>.IgnoreRight()
        {
            return this;
        }

        IRightCollector<T> ILeftSkipper<IRightCollector<T>>.IgnoreLeft()
        {
            return this;
        }

        IRightCollector<T> ILeftCollector<T>.Left(ref IList<T> collection)
        {
            foreach (var left in _left)
                collection.Add(left);

            return this;
        }

        void IRightCollector<T>.Right(ref IList<T> collection)
        {
            foreach (var right in _right)
            {
                collection.Add(right);
            }
        }
    }
}
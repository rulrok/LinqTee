using System;
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ITeeable<T>
    {
        private IEnumerable<T> _left;
        private IEnumerable<T> _right;

        private TeeContainer(IEnumerable<T> left, IEnumerable<T> right)
        {
            _left = left;
            _right = right;
        }

        internal static TeeContainer<T> Create(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var left = new List<T>();
            var right = new List<T>();

            foreach (var item in collection)
            {
                if (predicate(item))
                    left.Add(item);
                else
                    right.Add(item);
            }

            return new TeeContainer<T>(left, right);
        }

        public ILeftCollector<T> Collect()
        {
            return this;
        }
    }
}
using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : ITeeable<T>
    {
        private IEnumerable<T> _left;
        private IEnumerable<T> _right;

        internal TeeContainer(IEnumerable<T> left, IEnumerable<T> right)
        {
            _left = left;
            _right = right;
        }
    }
}
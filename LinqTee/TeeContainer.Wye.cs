using System.Collections.Generic;
using System.Linq;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : IWyeable<T>
    {
        public IEnumerable<T> ConcatenateLeft()
        {
            return _left.Concat(_right);
        }

        public IEnumerable<T> ConcatenateRight()
        {
            return _right.Concat(_left);
        }

        public IEnumerable<T> ZipLeft()
        {
            return _left.WyeZip(_right);
        }

        public IEnumerable<T> ZipRight()
        {
            return _right.WyeZip(_left);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : IWyer<T>, IWyeableOperation<T>
    {
        public IEnumerable<T> Concatenate()
        {
            return _left.Concat(_right);
        }

        public IEnumerable<T> ConcatenateRight()
        {
            return _right.Concat(_left);
        }

        public IEnumerable<T> Zip()
        {
            return _left.WyeZip(_right);
        }

        public IEnumerable<T> ZipRight()
        {
            return _right.WyeZip(_left);
        }
    }
}
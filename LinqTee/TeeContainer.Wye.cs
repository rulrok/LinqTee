using System.Collections.Generic;
using System.Linq;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T> : IWyeable<T>
    {
        public IEnumerable<T> Wye()
        {
            return _left.Concat(_right);
        }

        public IEnumerable<T> WyeRight()
        {
            return _right.Concat(_left);
        }

        public IEnumerable<T> WyeZip()
        {
            return _left.WyeZip(_right);
        }

        public IEnumerable<T> WyeZipRight()
        {
            return _right.WyeZip(_left);
        }
    }
}
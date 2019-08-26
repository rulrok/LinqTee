using System.Collections.Generic;
using LinqTee.Contracts;

namespace LinqTee
{
    public partial class TeeContainer<T>
    {
        public IWyeable<T> Wye()
        {
            _wyeRightToLeft = false;
            return this;
        }

        public IWyeable<T> WyeRight()
        {
            _wyeRightToLeft = true;
            return this;
        }

        public IEnumerable<T> OperateWith(IWyeableOperation<T> operation)
        {
            return _wyeRightToLeft
                ? operation.Operate(_right, _left)
                : operation.Operate(_left, _right);
        }
    }
}
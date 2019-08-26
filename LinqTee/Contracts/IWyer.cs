using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface IWyer<T>
    {
        IWyeable<T> Wye();

        IWyeable<T> WyeRight();
    }

    public interface IWyeable<T>
    {
        IEnumerable<T> OperateWith(IWyeableOperation<T> operation);
    }

    public interface IWyeableOperation<T>
    {
        IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right);
    }
}
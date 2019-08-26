using System.Collections.Generic;
using LinqTee.WyerOperations;

namespace LinqTee.Contracts
{
    /// <summary>
    /// It allows for 'wye-ing' (Y) as opposed to 'tee-ing' (T) items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWyer<T>
    {
        IWyeable<T> Wye();

        IWyeable<T> WyeRight();
    }

    /// <summary>
    /// This methods is exposed so consumers can pass any implementation they want,
    /// or use the ones provided by default through extension methods.
    /// </summary>
    /// <see cref="Concatenate{T}"/>
    /// <see cref="Zip{T}"/>
    /// <typeparam name="T"></typeparam>
    public interface IWyeable<T>
    {
        IEnumerable<T> OperateWith(IWyeableOperation<T> operation);
    }

    /// <summary>
    /// To create your own custom 'wye-ing' logic, inherit this class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWyeableOperation<T>
    {
        IEnumerable<T> Operate(IEnumerable<T> left, IEnumerable<T> right);
    }
}
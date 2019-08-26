using System;
using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface ITeeableProcessor<T>
    {
        ITeeableRemainder<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action);
    }

    public interface ITeeableRemainder<T>
    {
        IWyeable<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action);
    }

    public interface IWyeable<out T>
    {
        IEnumerable<T> Wye();

        IEnumerable<T> WyeRight();

        IEnumerable<T> WyeZip();

        IEnumerable<T> WyeZipRight();
    }
}
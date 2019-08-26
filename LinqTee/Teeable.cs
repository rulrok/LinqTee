using System;
using System.Collections.Generic;

namespace LinqTee
{
    public interface ITeeable<T>
    {
        ITeeableRemainder<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action);
    }

    public interface ITeeableCollector<T>
    {
        ITeeableColectorRemainder<T> LeftCollect(ref IList<T> collection);
        
        ITeeableColectorRemainder<T> IgnoreLeft();
    }

    public interface ITeeableColectorRemainder<T>
    {
        void RightCollect(ref IList<T> collection);

        void IgnoreRight();
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
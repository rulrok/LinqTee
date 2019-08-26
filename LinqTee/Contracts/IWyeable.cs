using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface IWyeable<out T>
    {
        IEnumerable<T> Wye();

        IEnumerable<T> WyeRight();

        IEnumerable<T> WyeZip();

        IEnumerable<T> WyeZipRight();
    }
}
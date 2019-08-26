using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface IWyeable<out T>
    {
        IEnumerable<T> ConcatenateLeft();

        IEnumerable<T> ConcatenateRight();

        IEnumerable<T> ZipLeft();

        IEnumerable<T> ZipRight();
    }
}
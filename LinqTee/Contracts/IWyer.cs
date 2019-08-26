using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface IWyer<out T>
    {
        IWyeableOperation<T> Wye();
    }
    
    public interface IWyeableOperation<out T>
    {
        IEnumerable<T> Concatenate();

        IEnumerable<T> ConcatenateRight();

        IEnumerable<T> Zip();

        IEnumerable<T> ZipRight();
    }
}
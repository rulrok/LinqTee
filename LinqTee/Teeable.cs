using System;
using System.Collections.Generic;

namespace LinqTee
{
    public interface ITeeable<T>
    {
        ITeeable<T> Left(Func<IEnumerable<T>, IEnumerable<T>> action);
        IWyeable<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action);
    }

    public interface IWyeable<out T>
    {
        IEnumerable<T> Wye();
    }
}
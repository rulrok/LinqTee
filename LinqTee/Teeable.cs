using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LinqTee
{
    public interface ITeeable<T>
    {
        ITeeable<T> Left(Expression<Func<IEnumerable<T>, IEnumerable<T>>> action);
        IWyeable<T> Right(Expression<Func<IEnumerable<T>, IEnumerable<T>>> action);
    }

    public interface IWyeable<out T>
    {
        IEnumerable<T> Wye();
    }
}
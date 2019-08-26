using System;
using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface ITeeableProcessor<T>
    {
        ILeftProcessor<T> Process();
    }

    public interface ILeftProcessor<T>
    {
        IRightProcessor<T> Left(Func<IEnumerable<T>, IEnumerable<T>> selector);
    }

    public interface IRightProcessor<T>
    {
        IWyeable<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action);
    }
}
using System;
using System.Collections.Generic;

namespace LinqTee.Contracts
{
    /// <summary>
    /// Allow to process individual left/right items and return them to mutate the Tee operation/container.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITeeableProcessor<T>
    {
        ILeftProcessor<T> Process();
    }

    public interface ILeftProcessor<T> : ILeftSkipper<IRightProcessor<T>>
    {
        IRightProcessor<T> Left(Func<IEnumerable<T>, IEnumerable<T>> selector);
    }

    public interface IRightProcessor<T> : IRightSkipper<IWyer<T>>
    {
        IWyer<T> Right(Func<IEnumerable<T>, IEnumerable<T>> action);
    }
}
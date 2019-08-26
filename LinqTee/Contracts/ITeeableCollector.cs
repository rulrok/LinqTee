using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface ITeeableCollector<T>
    {
        ILeftCollector<T> Collect();
    }

    public interface ILeftCollector<T> : ILeftSkipper<IRightCollector<T>>
    {
        IRightCollector<T> Left(ref IList<T> collection);
    }

    public interface IRightCollector<T> : IRightSkipper<ITeeable<T>>
    {
        void Right(ref IList<T> collection);
    }
}
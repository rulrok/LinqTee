using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface ITeeableCollector<T>
    {
        ILeftCollector<T> Collect();
    }

    public interface ILeftCollector<T>
    {
        IRightCollector<T> Left(ref IList<T> collection);

        IRightCollector<T> IgnoreLeft();
    }

    public interface IRightCollector<T>
    {
        void Right(ref IList<T> collection);

        void IgnoreRight();
    }
}
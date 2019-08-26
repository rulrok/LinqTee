using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface ITeeableCollector<T> : ILeftSkipper<ITeeableColectorRemainder<T>>
    {
        ITeeableColectorRemainder<T> LeftCollect(ref IList<T> collection);
    }

    public interface ITeeableColectorRemainder<T> : IRightSkipper
    {
        void RightCollect(ref IList<T> collection);
    }
}
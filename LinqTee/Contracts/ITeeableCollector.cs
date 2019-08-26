using System.Collections.Generic;

namespace LinqTee.Contracts
{
    public interface ITeeableCollector<T>
    {
        ITeeableColectorRemainder<T> LeftCollect(ref IList<T> collection);

        ITeeableColectorRemainder<T> IgnoreLeft();
    }

    public interface ITeeableColectorRemainder<T>
    {
        void RightCollect(ref IList<T> collection);

        void IgnoreRight();
    }
}
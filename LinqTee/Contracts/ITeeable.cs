namespace LinqTee.Contracts
{
    public interface ITeeable<T> : ITeeableCollector<T>, ITeeableSplitter<T>
    {
    }
}
namespace LinqTee.Contracts
{
    public interface ITeeable<T> : ITeeableCollector<T>, ITeeableProcessor<T>
    {
    }
}
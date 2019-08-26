namespace LinqTee.Contracts
{
    /// <summary>
    /// A 'teeable' container exposes the three main operations to consumers.
    ///
    /// Once 'tee-ed', an enumerable can be operated upon using:
    /// <para>
    /// <see cref="ITeeableCollector{T}"/> To collect left/right items to an external ref collection.
    /// </para>
    /// <para>
    /// <see cref="ITeeableProcessor{T}"/> Process left/right items on a .ForEach() function style.
    /// Notice that it will mutate the Tee container!
    /// </para>
    /// <para>
    /// <see cref="IWyer{T}"/> After 'teeing' an enumerable, you can 'wye' it using any available operation, like concatenating and zipping.
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITeeable<T> : ITeeableCollector<T>, ITeeableProcessor<T>, IWyer<T>
    {
    }
}
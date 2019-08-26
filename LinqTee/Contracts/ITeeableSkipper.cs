namespace LinqTee.Contracts
{
    /// <summary>
    /// It allows to ignore processing the left side of the tee.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILeftSkipper<out T>
    {
        T IgnoreLeft();
    }

    /// <summary>
    /// It allows to ignore processing the right side of the tee.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRightSkipper<out T>
    {
        T IgnoreRight();
    }
}
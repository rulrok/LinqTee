namespace LinqTee.Contracts
{
    public interface ILeftSkipper<out T>
    {
        T IgnoreLeft();
    }

    public interface IRightSkipper<out T>
    {
        T IgnoreRight();
    }

    public interface IRightSkipper
    {
        void IgnoreRight();
    }
}
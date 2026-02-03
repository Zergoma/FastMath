namespace FastMath.Core.Interfaces
{
    public interface IReadData<T> where T : class
    {
        T Read();
    }
}

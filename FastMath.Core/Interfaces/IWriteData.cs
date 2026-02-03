namespace FastMath.Core.Interfaces
{
    public interface IWriteData<T> where T : class
    {
        void Write(T value);
    }
}

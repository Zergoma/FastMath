namespace FastMath.Core.Interfaces
{
    public interface IDataLayer<T> : IReadData<T>, IWriteData<T>
        where T : class;
}

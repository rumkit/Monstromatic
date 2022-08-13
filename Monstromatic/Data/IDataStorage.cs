namespace Monstromatic.Data
{
    public interface IDataStorage<T>
    {
        T Read();
        void Save(T data);
    }
}
using System.Threading.Tasks;

namespace Monstromatic.Data
{
    public interface IDataStore<T>
    {
        T Read();
        void Save(T data);
    }
}
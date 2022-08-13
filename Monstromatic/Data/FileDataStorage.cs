using System.IO;
using Monstromatic.Extensions;

namespace Monstromatic.Data
{
    public class FileDataStorage<T> : IDataStorage<T>
    {
        private readonly string _fileName;

        public FileDataStorage(string fileName)
        {
            _fileName = fileName;
        }

        public T Read()
        {
            using var stream = File.OpenRead(_fileName);
            return stream.FromJson<T>();
        }

        public void Save(T data)
        {
            using var stream = File.Open(_fileName, FileMode.Create);
            using var jsonStream = data.ToJson();
            jsonStream.CopyTo(stream);
        }
    }
}
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Monstromatic.Extensions;

namespace Monstromatic.Data
{
    public class FileDataStorage<T> : IDataStorage<T>
    {
        public string FileName { get; }
        public string BasePath { get; }
    
        public FileDataStorage(string basePath, string fileName)
        {
            BasePath = basePath;
            FileName = fileName;
        }


        public T Read()
        {
            using var stream = File.OpenRead(Path.Combine(BasePath, FileName));
            return stream.FromJson<T>();
        }

        public void Save(T data)
        {
            using var stream = File.OpenWrite(Path.Combine(BasePath, FileName));
            using var jsonStream = data.ToJson();
            jsonStream.CopyTo(stream);
        }
    }
}
using System.IO;
using System.Text.Json;

namespace Monstromatic.Data
{
    public class FileDataStore<T> : IDataStore<T>
    {
        public string FileName { get; }
        public string BasePath { get; }
    
        public FileDataStore(string basePath, string fileName)
        {
            BasePath = basePath;
            FileName = fileName;
        }


        public T Read()
        {
            using var stream = File.OpenRead(Path.Combine(BasePath, FileName));
            return JsonSerializer.Deserialize<T>(stream);
        }

        public void Save(T data)
        {
            using var stream = File.OpenWrite(Path.Combine(BasePath, FileName));
            JsonSerializer.Serialize(stream, data);
        }
    }
}
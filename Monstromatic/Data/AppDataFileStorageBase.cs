using System;
using System.IO;
using System.Reflection;
using Monstromatic.Extensions;
using Monstromatic.Utils;

namespace Monstromatic.Data
{
    public abstract class AppDataFileStorageBase<T> : IDataStorage<T>
    {
        private readonly string _basePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Monstromatic");

        private readonly IDataStorage<T> _dataStorage;

        public AppDataFileStorageBase(string fileName, string resourceName)
        {
            _dataStorage = new FileDataStorage<T>(_basePath, Path.Combine(_basePath, fileName));
            
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
            if (!File.Exists(Path.Combine(_basePath, fileName)))
                _dataStorage.Save(data: GetDefaultSettings(resourceName));
        }

        private static T GetDefaultSettings(string resourceName)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream(typeof(SettingsStorage), resourceName) ??
                        throw new InvalidOperationException("Cannot open resources stream");
                return stream.FromJson<T>();
            }
            catch(Exception e)
            {
                throw new AppException("Failed to load settings", e);
            }
        }

        public T Read()
        { 
            return _dataStorage.Read();
        }

        public void Save(T data)
        {
            _dataStorage.Save(data);
        }
    }
}
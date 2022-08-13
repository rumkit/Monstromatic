using System;
using System.IO;
using System.Reflection;
using Monstromatic.Extensions;
using Monstromatic.Utils;

namespace Monstromatic.Data
{
    public interface IAppDataStorage<T> : IDataStorage<T>
    {
        void ResetToDefault();
    }
    
    public abstract class AppDataFileStorageBase<T> : IAppDataStorage<T>
    {
        private readonly string _resourceName;
        private readonly IDataStorage<T> _dataStorage;

        protected AppDataFileStorageBase(string fileName, string resourceName)
        {
            _resourceName = resourceName;
            _dataStorage = new FileDataStorage<T>(fileName);

            var directory = Path.GetDirectoryName(Path.GetFullPath(fileName));
            
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            if (!File.Exists(fileName))
                ResetToDefault();
        }

        private T GetDefaultSettings()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream(typeof(SettingsStorage), _resourceName) ??
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
            try
            {
                return _dataStorage.Read();
            }
            catch
            {
                return GetDefaultValue();
            }
        }

        protected abstract T GetDefaultValue();

        public void Save(T data)
        {
            _dataStorage.Save(data);
        }

        public void ResetToDefault()
        {
            _dataStorage.Save(data: GetDefaultSettings());
        }
    }
}